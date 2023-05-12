using System;
using System.Drawing;

namespace Gravity_Simulator
{
    class Attracter
    {
        public Vector2 startingLocation;
        public string Name;
        public SolidBrush Color;
        public SolidBrush startingColor;
        public Vector2 Size;

        public Vector2 location;
        public Vector2 otherLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 acceleration = new Vector2(0, 0);
        public float mass;
        public float otherMass;
        public int multiplier;

        public Circle circle = new Circle();
        public Circle otherCircler = new Circle();

        public Attracter(String Name, Vector2 Size, Vector2 startingPosition, SolidBrush sb)
        {
            this.Name = Name;
            this.Size = Size;
            this.startingLocation = startingPosition;
            this.Color = sb;

            this.circle.position = location;
            this.circle.width = (float)Size.x;
            this.circle.height = (float)Size.y;
            this.circle.radius = (float)this.circle.width / 2;
        }

        public Attracter(String Name, Vector2 Size, float mass, Vector2 startingPosition, SolidBrush sb)
        {
            this.Name = Name;
            this.Size = Size;
            this.mass = mass;
            this.startingLocation = startingPosition;
            this.Color = sb;

            this.circle.position = location;
            this.circle.width = (float)Size.x;
            this.circle.height = (float)Size.y;
            this.circle.radius = (float)this.circle.width / 2;
        }

        public Vector2 centerLocation()
        {
            return new Vector2(this.location.x + (this.circle.width / 2), this.location.y + (this.circle.height / 2));
        }

        public double slope()
        {
            return (location.y - startingLocation.y) / (location.x - startingLocation.x);
        }

        public void ApplyForce(Vector2 force)
        {
            Vector2 f = new Vector2();
            f.div(force, mass);
            acceleration.add(f);
        }

        public void Move()
        {
            velocity.add(acceleration);
            location.add(velocity);
            //Collision.resolveCollision(this.circle, this.otherCircler);
            acceleration.mult(0);
        }

        public double speed()
        {
            return Math.Sqrt(Math.Pow(velocity.x, 2) + Math.Pow(velocity.y, 2));
        }

        private float constrain(float amt, float low, float high)
        {
            if (amt > high)
            {
                return high;
            }
            else if (amt < low)
            {
                return low;
            }
            else
            {
                return amt;
            }
        }

        public Vector2 CalculateForce()
        {
            double G = 0.0000000000667; //0.0000000000667

            Vector2 force = new Vector2();
            force.sub(otherLocation, location);
            float distance = force.mag();
            //distance = constrain(distance, 100 + 10, 500);
            //force.normalize();

            double strength = G * (mass * otherMass / (float)Math.Pow(distance, 2));//(G * mass * p.mass) / (distance * distance);

            force.mult((float)strength);

            //force.mult(100000000000);
            return force;
        }
    }
}
