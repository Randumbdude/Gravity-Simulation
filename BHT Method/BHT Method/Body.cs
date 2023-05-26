namespace BHT_Method
{
    public class Body
    {
        public double Mass { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public double Radius { get; set; }
        public double Restitution { get; set; } // Coefficient of restitution
    }
}
