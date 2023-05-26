using System;

namespace BHT_Method
{
    public class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector2 Add(Vector2 other)
        {
            return new Vector2(X + other.X, Y + other.Y);
        }

        public Vector2 Subtract(Vector2 other)
        {
            return new Vector2(X - other.X, Y - other.Y);
        }

        public Vector2 Multiply(double scalar)
        {
            return new Vector2(X * scalar, Y * scalar);
        }
        public Vector2 Multiply(Vector2 scalar)
        {
            return new Vector2(X * scalar.X, Y * scalar.Y);
        }
        public Vector2 Normalize()
        {
            double magnitude = Magnitude();
            if (magnitude > 0)
            {
                return new Vector2(X / magnitude, Y / magnitude);
            }
            else
            {
                return new Vector2(0, 0);
            }
        }
        public double Dot(Vector2 other)
        {
            return X * other.X + Y * other.Y;
        }
    }
}
