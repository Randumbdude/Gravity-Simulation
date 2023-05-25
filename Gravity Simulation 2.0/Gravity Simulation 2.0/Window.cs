using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gravity_Simulation_2._0
{
    public partial class Window : Form
    {
        private List<Body> bodies;

        Body body1 = new Body(1000, 10, 500, 300, -0.000001, 0.000001, new SolidBrush(Color.DeepPink));
        Body body2 = new Body(1, 10, 500, 350, -0.00003, -0.00003, new SolidBrush(Color.Cyan));
        Body body3 = new Body(1, 10, 550, 300, -0.00003, -0.00003, new SolidBrush(Color.Green));

        Shader shader;

        //gameloop
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly FastLoop _fastLoop;
        private long _msFrameTime;
        private long _msLastFrame;
        private long _msPerDrawCycle;
        private long _msThisFrame;
        private long _frameTime;

        //drawing
        Font debugFont = new Font(FontFamily.GenericMonospace, 10);
        SolidBrush debugBrush = new SolidBrush(Color.WhiteSmoke);

        //mouse
        private PointF StartPointF { get; set; }
        private bool mouseDown;

        public Window()
        {
            bodies = new List<Body>();

            InitializeComponent();

            _fastLoop = new FastLoop(GameLoop);
            _stopwatch.Start();

            AddBody(body1);
            AddBody(body2);
            AddBody(body3);
        }

        private void simBox_Paint(object sender, PaintEventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawString("frame rate: " + 1000 / Math.Max(_msFrameTime, 1), debugFont, debugBrush, new PointF(0, 0));
            e.Graphics.DrawString($"Grid Offset: (X:{(int)Constants.xGridOffset},Y:{(int)Constants.yGridOffset})", debugFont, debugBrush, new PointF(0, 15));

            Simulate(1, 50000);

            shader = new DefaultShader();

            foreach (Body b in bodies)
            {
                shader.PreDraw(b, e.Graphics);
                shader.Draw(b, e.Graphics);
                shader.PostDraw(b, e.Graphics);
            }
        }

        private void AddBody(Body body)
        {
            bodies.Add(body);
        }

        public void Simulate(double timeStep, double duration)
        {
            int steps = (int)(duration / timeStep);

            for (int step = 0; step < steps; step++)
            {
                // Calculate forces between all pairs of bodies
                for (int i = 0; i < bodies.Count - 1; i++)
                {
                    for (int j = i + 1; j < bodies.Count; j++)
                    {
                        CalculateForce(bodies[i], bodies[j]);
                    }
                }

                // Update positions and velocities of bodies
                foreach (Body body in bodies)
                {
                    UpdatePosition(body, timeStep);
                }

                HandleCollisions();
            }
        }

        private void CalculateForce(Body body1, Body body2)
        {
            double dx = body2.X - body1.X;
            double dy = body2.Y - body1.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            double force = (Constants.G * body1.Mass * body2.Mass) / (distance * distance);

            double angle = Math.Atan2(dy, dx);
            double fx = force * Math.Cos(angle);
            double fy = force * Math.Sin(angle);

            body1.Vx += fx / body1.Mass;
            body1.Vy += fy / body1.Mass;
            body2.Vx -= fx / body2.Mass;
            body2.Vy -= fy / body2.Mass;
        }

        private void UpdatePosition(Body body, double timeStep)
        {
            body.X += body.Vx * timeStep;
            body.Y += body.Vy * timeStep;
        }

        private void HandleCollisions()
        {
            for (int i = 0; i < bodies.Count - 1; i++)
            {
                for (int j = i + 1; j < bodies.Count; j++)
                {
                    if (CheckCollision(bodies[i], bodies[j]))
                    {
                        ResolveCollision(bodies[i], bodies[j]);
                    }
                }
            }
        }

        private bool CheckCollision(Body body1, Body body2)
        {
            double dx = body2.X - body1.X;
            double dy = body2.Y - body1.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            return distance < (body1.Radius + body2.Radius);
        }

        private void ResolveCollision(Body body1, Body body2)
        {
            double dx = body2.X - body1.X;
            double dy = body2.Y - body1.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            double nx = dx / distance;
            double ny = dy / distance;

            double dvx = body2.Vx - body1.Vx;
            double dvy = body2.Vy - body1.Vy;

            double normalSpeed = dvx * nx + dvy * ny;

            if (normalSpeed >= 0) // Bodies are moving apart
                return;

            double impulse = (2 * normalSpeed) / (body1.Mass + body2.Mass);

            body1.Vx += impulse * body2.Mass * nx;
            body1.Vy += impulse * body2.Mass * ny;
            body2.Vx -= impulse * body1.Mass * nx;
            body2.Vy -= impulse * body1.Mass * ny;
        }

        private void simBox_MouseDown(object sender, MouseEventArgs e)
        {
            StartPointF = e.Location;
            mouseDown = true;
        }

        private void simBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && e.Button == MouseButtons.Right)
            {
                this.Cursor = Cursors.Cross;
                Constants.xGridOffset += (StartPointF.X - e.X) * -1 / 10;
                Constants.yGridOffset += (StartPointF.Y - e.Y) * -1 / 10;
            }
        }

        private void simBox_MouseUp(object sender, MouseEventArgs e) { }


        private void GameLoop(double elapsedTime)
        {
            int fps = 60;

            if (_stopwatch.ElapsedMilliseconds - _frameTime > 1000 / fps)
            {
                _frameTime = _stopwatch.ElapsedMilliseconds;
                simBox.Refresh(); //redraw picturebox
                _msPerDrawCycle = _stopwatch.ElapsedMilliseconds - _frameTime;
                _msLastFrame = _msThisFrame;
                _msThisFrame = _stopwatch.ElapsedMilliseconds;
                _msFrameTime = _msThisFrame - _msLastFrame;
            }
        }
    }
}
