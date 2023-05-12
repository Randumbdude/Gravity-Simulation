using System;
using System.Drawing;

namespace Gravity_Simulator.Objects
{
    class Planet : Attracter
    {
        public Circle circle;

        public Planet(String Name, Vector2 Size, float mass, Vector2 startingPosition, SolidBrush sb) : base(Name, Size, mass, startingPosition, sb)
        {
            this.Name = Name;
            this.Size = Size;
            this.mass = mass;
            this.startingLocation = startingPosition;
            this.Color = sb;

            this.circle.position = startingPosition;
            this.circle.width = (float)Size.x;
            this.circle.height = (float)Size.y;
            this.circle.radius = (float)this.circle.width / 2 + (float)Math.Pow(this.circle.height, 2) / (float)(8 * this.circle.width);
        }
    }
}
