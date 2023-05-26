using System.Drawing;

namespace Gravity_Simulation_2._0
{
    class Body
    {
        public double Mass { get; set; }
        public double Radius { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Vx { get; set; }
        public double Vy { get; set; }
        public SolidBrush color { get; set; }

        public Body(double mass, double size, double x, double y, double vx, double vy, SolidBrush color)
        {
            Mass = mass;
            Radius = size / 2;
            X = x;
            Y = y;
            Vx = vx;
            Vy = vy;
            this.color = color;
        }
    }
}
