using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BHT_Method
{
    public partial class Form1 : Form
    {
        Body body1 = new Body { Mass = 10, Position = new Vector2(300, 300), Velocity = new Vector2(0, 0), Radius = 2.5 };
        Body body2 = new Body { Mass = 20, Position = new Vector2(400, 350), Velocity = new Vector2(0, 0), Radius = 2.5 };
        Body body3 = new Body { Mass = 30, Position = new Vector2(350, 375), Velocity = new Vector2(0, 0), Radius = 2.5 };

        BarnesHutSimulation simulation = new BarnesHutSimulation();

        double timeStep = 100000;

        // Generate spiral pattern
        List<Vector2> particlePositions;

        // Create bodies and set initial positions
        List<Body> bodies = new List<Body>();

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

        public Form1()
        {
            InitializeComponent();

            _fastLoop = new FastLoop(GameLoop);
            _stopwatch.Start();

            simulation.AddBody(body1);
            simulation.AddBody(body2);
            simulation.AddBody(body3);

            particlePositions = GenerateSpiralPattern(150, 1, 100, 10);

            foreach (Vector2 position in particlePositions)
            {
                Body body = new Body();
                body.Mass = 10;
                body.Radius = 2.5;
                body.Position = position;
                body.Velocity = new Vector2(0.00001, 0); // Set initial velocity as needed
                body.Restitution = 0.08; // Set the desired restitution value

                bodies.Add(body);
            }

            foreach (Body body in bodies)
            {
                // Add the body to your simulation data structure or collection
                // For example, if you have a List<Body> called 'simulationBodies', you can add the body as follows:
                simulation.AddBody(body);
            }
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

            simulation.Simulate(timeStep);

            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), (float)body1.Position.X, (float)body1.Position.Y, 5, 5);
            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), (float)body2.Position.X, (float)body2.Position.Y, 5, 5);
            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), (float)body3.Position.X, (float)body3.Position.Y, 5, 5);

            foreach (Body b in bodies)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), (float)b.Position.X, (float)b.Position.Y, 5, 5);
            }
        }

        private List<Vector2> GenerateSpiralPattern(int numParticles, double startRadius, double endRadius, double angleOffset)
        {
            List<Vector2> particles = new List<Vector2>();

            for (int i = 0; i < numParticles; i++)
            {
                double angle = (i * angleOffset) * (Math.PI / 180.0);
                double radius = startRadius + (endRadius - startRadius) * (angle / (2 * Math.PI));

                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);

                particles.Add(new Vector2(x + 300, y + 300));
            }

            return particles;
        }

        private void GameLoop(double elapsedTime)
        {
            int fps = 60;

            if (_stopwatch.ElapsedMilliseconds - _frameTime > 1000 / fps)
            {
                Render();
            }
        }

        private void Render()
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
