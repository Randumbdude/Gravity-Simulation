using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Gravity_Simulator
{
    public partial class Window : Form
    {
        //objects in space
        static Attracter planet = new Attracter("Planet", new Vector2(17, 17), new Vector2(300, 200), new SolidBrush(Color.DeepSkyBlue));
        static Attracter otherPlanet = new Attracter("otherPlanet", new Vector2(12, 12), new Vector2(600, 300), new SolidBrush(Color.ForestGreen));
        static Attracter sun = new Attracter("Sun", new Vector2(30, 30), new Vector2(500, 400), new SolidBrush(Color.Orange));

        static List<Attracter> attracterList = new List<Attracter>();

        double xstartingForce;
        double ystartingForce;

        //gameloop
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly FastLoop _fastLoop;
        private long _msFrameTime;
        private long _msLastFrame;
        private long _msPerDrawCycle;
        private long _msThisFrame;
        private long _frameTime;
        public static bool isRunning;

        //drawing
        Font debugFont = new Font(FontFamily.GenericMonospace, 10);
        SolidBrush debugBrush = new SolidBrush(Color.WhiteSmoke);
        static Pen statPen = new Pen(Color.White, 3);

        static Pen linePen = new Pen(Color.Red, 3);

        static List<SolidBrush> sbList = new List<SolidBrush>();

        //mouse
        private PointF StartPointF { get; set; }
        private int mouseWheelValue;
        private bool mouseDown;

        //shaders
        static Shader shader;

        //other
        static bool didPressStop = false;
        static Random rnd = new Random();
        double accumulator = 0.0;

        public Window()
        {
            attracterList.Add(planet);
            attracterList.Add(sun);
            //attracterList.Add(otherPlanet);

            InitializeComponent();

            this.simPanel.MouseWheel += simPanel_MouseWheel;

            _fastLoop = new FastLoop(GameLoop);
            _stopwatch.Start();


            foreach (Attracter b in attracterList)
            {
                b.location = b.startingLocation;
                b.startingColor = b.Color;
            }
        }

        private void simPanel_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (defaultShaderCheck.Checked)
            {
                shader = new ShaderDefault();
            }
            if (infoShaderCheckBox.Checked)
            {
                shader = new InfoShader();
            }

            if (isRunning)
            {
                foreach (Attracter a in attracterList)
                {
                    foreach (Attracter b in attracterList)
                    {
                        if (a != b)
                        {
                                calculateGravity(a, b);
                        }
                    }
                }
            }

            e.Graphics.DrawString("frame rate: " + 1000 / Math.Max(_msFrameTime, 1), debugFont, debugBrush, new PointF(0, 0));
            e.Graphics.DrawString("object count: " + attracterList.Count, debugFont, debugBrush, new PointF(0, 15));
            e.Graphics.DrawString($"grid offset: ({grid.xgridOffset}, {grid.ygridOffset})", debugFont, debugBrush, new PointF(0, 30));

            foreach (Attracter a in attracterList)
            {
                shader.PreDraw(a, e.Graphics);
                shader.Draw(a, e.Graphics);
                shader.PostDraw(a, e.Graphics);
            }
        }

        private void calculateGravity(Attracter attracter1, Attracter attracter2)
        {
            attracter1.otherMass = attracter2.mass;

            attracter1.location.Update(attracter1.location.x, attracter1.location.y);
            attracter1.otherLocation.Update(attracter2.location.x, attracter2.location.y);
            Vector2 Force = attracter1.CalculateForce();
            attracter1.ApplyForce(Force);
            attracter1.Move();

            Collision.resolveCollision(simPanel, attracter1, attracter2, boundriesCheck.Checked, collisionsCheck.Checked);
        }

        private void GameLoop(double elapsedTime)
        {
            int fps = timeWarpBar.Value;

            if (_stopwatch.ElapsedMilliseconds - _frameTime > 1000 / fps)
            {
                Render();
            }
        }

        private void Render()
        {
            _frameTime = _stopwatch.ElapsedMilliseconds;
            simPanel.Refresh(); //redraw picturebox
            _msPerDrawCycle = _stopwatch.ElapsedMilliseconds - _frameTime;
            _msLastFrame = _msThisFrame;
            _msThisFrame = _stopwatch.ElapsedMilliseconds;
            _msFrameTime = _msThisFrame - _msLastFrame;
        }

        private void simPanel_MouseDown(object sender, MouseEventArgs e)
        {
            StartPointF = e.Location;
            mouseDown = true;
        }

        private void simPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (mouseWheelValue > 10 && e.Button == MouseButtons.Left)
            {
                Attracter newPlanet;

                if (mouseWheelValue > 450)
                {
                    newPlanet = new Attracter("New Planet", new Vector2(mouseWheelValue / 2, mouseWheelValue / 2), mouseWheelValue * 1000000000, new Vector2(e.X, e.Y), new SolidBrush(Color.Black));
                }
                else
                {
                    newPlanet = new Attracter("New Planet", new Vector2(mouseWheelValue / 2, mouseWheelValue / 2), mouseWheelValue * 1000000, new Vector2(e.X, e.Y), new SolidBrush(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))));
                    newPlanet.startingColor = newPlanet.Color;
                }

                newPlanet.location.Update(e.X, e.Y);

                attracterList.Add(newPlanet);
            }
        }

        private void simPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && e.Button == MouseButtons.Right)
            {
                this.Cursor = Cursors.Cross;
                //isRunning = false;
                grid.xgridOffset += (StartPointF.X - e.X) * -1 / 100;
                grid.ygridOffset += (StartPointF.Y - e.Y) * -1 / 100;
            }
            else
            {
                //isRunning = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void simPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            mouseWheelValue += numberOfTextLinesToMove;
            Console.WriteLine(mouseWheelValue);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateButton.Enabled = false;
            xstartingForce = Convert.ToDouble(xforceTextBox.Text);
            ystartingForce = Convert.ToDouble(yforceTextBox.Text);

            planet.mass = Int64.Parse(planetMassTextBox.Text);
            otherPlanet.mass = Int64.Parse(otherMassTextBox.Text);
            sun.mass = Int64.Parse(sunMassTextBox.Text);

            if (!didPressStop)
            {
                planet.velocity.Update(xstartingForce, ystartingForce);
            }

            didPressStop = false;
            isRunning = true;
        }


        private void stopButton_Click(object sender, EventArgs e)
        {
            CalculateButton.Enabled = true;
            isRunning = false;
            didPressStop = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            CalculateButton.Enabled = true;
            isRunning = false;

            xstartingForce = 0;
            ystartingForce = 0;

            grid.xgridOffset = 0;
            grid.ygridOffset = 0;

            foreach (Attracter a in attracterList)
            {
                a.location.Update(a.startingLocation.x, a.startingLocation.y);
                a.velocity.Update(0, 0);
                a.acceleration.Update(0, 0);
            }
        }

        private void defaultShaderCheck_CheckedChanged(object sender, EventArgs e)
        {
            infoShaderCheckBox.Checked = !defaultShaderCheck.Checked;
        }

        private void velShaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            defaultShaderCheck.Checked = !infoShaderCheckBox.Checked;
        }
    }
}