using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Gravity_Simulator
{
    public partial class mainWindow : Form
    {
        static bool isRunning;

        static Attracter planet = new Attracter();
        static Attracter sun = new Attracter();

        int startingForce;

        public mainWindow()
        {
            InitializeComponent();

            //planet mass: 100000000000
            //   sun mass: 100000000000000

            //planet
            planet.location = new Vector2(planetPictureBox.Location.X, planetPictureBox.Location.Y);
            planet.otherLocation = new Vector2(sunPictureBox.Location.X, sunPictureBox.Location.Y);
            planet.velocity = new Vector2(0, 0);
            planet.acceleration = new Vector2(0, 0);
            planet.mass = 100000000000;
            planet.otherMass = 100000000000000;

            //sun
            sun.location = new Vector2(sunPictureBox.Location.X, sunPictureBox.Location.Y);
            sun.otherLocation = new Vector2(planetPictureBox.Location.X, planetPictureBox.Location.Y);
            sun.velocity = new Vector2(0, 0);
            sun.acceleration = new Vector2(0, 0);
            sun.mass = 100000000000000;
            sun.otherMass = 100000000000;
            
            this.WindowState = FormWindowState.Maximized;

            //round sun picture box
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, sunPictureBox.Width - 5, sunPictureBox.Height - 5);
            Region rg = new Region(gp);
            sunPictureBox.Region = rg;
            //round planet picture box
            System.Drawing.Drawing2D.GraphicsPath gp1 = new System.Drawing.Drawing2D.GraphicsPath();
            gp1.AddEllipse(0, 0, planetPictureBox.Width - 4, planetPictureBox.Height - 4);
            Region rg1 = new Region(gp1);
            planetPictureBox.Region = rg1;

            //disable sreen saver
    }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                startingForce = Int32.Parse(startingForceTextBox.Text);
            }
            catch
            {
                startingForce = 0;
            }

            planet.acceleration.Update(startingForce, startingForce);

            isRunning = true;

            while (isRunning == true)
            {
                Application.DoEvents();

                //planet
                planet.location.Update(planetPictureBox.Location.X, planetPictureBox.Location.Y);
                planet.otherLocation.Update(sunPictureBox.Location.X, sunPictureBox.Location.Y);
                Vector2 PlanetForce = planet.CalculateForce();
                planet.ApplyForce(PlanetForce);
                planet.Move();
                xLabel.Text = "Planet X: " + planet.location.x.ToString();
                yLabel.Text = "Planet Y: " + planet.location.y.ToString();
                planetPictureBox.Location = new Point(Convert.ToInt32(planet.location.x), Convert.ToInt32(planet.location.y));

                //sun
                sun.location.Update(sunPictureBox.Location.X, sunPictureBox.Location.Y);
                sun.otherLocation.Update(planetPictureBox.Location.X, planetPictureBox.Location.Y);
                Vector2 SunForce = sun.CalculateForce();
                sun.ApplyForce(SunForce);
                sun.Move();
                SunX.Text = "Sun X: " + sun.location.x.ToString();
                SunY.Text = "Sun Y: " + sun.location.y.ToString();
                sunPictureBox.Location = new Point(Convert.ToInt32(sun.location.x), Convert.ToInt32(sun.location.y));

                Thread.Sleep(1);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            isRunning = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
         /*   
            isRunning = false;
            planet.otherLocation.Update(993, 510);
            planet.location.Update(1086, 417);
            planet.velocity.Update(0, 0);
            planet.acceleration.Update(0, 0);

            sun.otherLocation.Update(1086, 417);
            sun.location.Update(993, 510);
            sun.velocity.Update(0, 0);
            sun.acceleration.Update(0, 0);

            planetPictureBox.Location = new Point(Convert.ToInt32(planet.location.x), Convert.ToInt32(planet.location.y));

            sunPictureBox.Location = new Point(Convert.ToInt32(sun.location.x), Convert.ToInt32(sun.location.y));
         */
        }
    }
}

//GRAVITY FORMULA
//---------------
//
//    F = G(m1m2)/r^2 
//
//F = Gravity Force
//G = Gravity
//m1 = mass of object 1
//m2 = mass of object 2
//r = distance between masses


/*
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            //OnPaint method is a member of Form class 
            //The following call sends pe to an event listener Graphics
            base.OnPaint(pe);


            Graphics g = pe.Graphics;
            Pen pn = new Pen(Color.Blue, 100);
            Rectangle rect = new Rectangle(225, 200, 50, 50);
            g.DrawEllipse(pn, rect);

            
        }
*/