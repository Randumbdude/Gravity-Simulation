using System;
using System.Windows.Forms;

namespace Gravity_Simulator
{
    class Collision
    {
        public static void resolveCollision(PictureBox simPanel, Attracter a, Attracter b, bool bc, bool cc)
        {
            float dx = (float)(b.circle.centerLocation.x - a.circle.centerLocation.x);
            float dy = (float)(b.circle.centerLocation.y - a.circle.centerLocation.y);
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (Math.Pow(b.centerLocation().x - a.centerLocation().x, 2) + Math.Pow(b.centerLocation().y - a.centerLocation().y, 2) <= Math.Pow(a.circle.radius + b.circle.radius, 2) && cc)
            {
                Console.WriteLine("Collided");

                // Calculate the unit normal and unit tangent vectors
                float nx = dx / distance;  // Normal vector component along the x-axis
                float ny = dy / distance;  // Normal vector component along the y-axis
                float tx = -ny;           // Tangent vector component along the x-axis
                float ty = nx;            // Tangent vector component along the y-axis

                // Calculate the velocity components along the normal and tangent vectors
                float v1n = (float)(a.velocity.x * nx + a.velocity.y * ny);
                float v1t = (float)(a.velocity.x * tx + a.velocity.y * ty);
                float v2n = (float)(b.velocity.x * nx + b.velocity.y * ny);
                float v2t = (float)(b.velocity.x * tx + b.velocity.y * ty);

                // Calculate the new normal velocity components after collision using one-dimensional elastic collision equations
                float v1nAfter = (v1n * (a.mass - b.mass) + 2 * b.mass * v2n) / (a.mass + b.mass);
                float v2nAfter = (v2n * (b.mass - a.mass) + 2 * a.mass * v1n) / (a.mass + b.mass);

                // Calculate the new velocities along the normal and tangent vectors
                //circle1.VelocityX = v1nAfter * nx + v1t * tx;
                //circle1.VelocityY = v1nAfter * ny + v1t * ty;
                //circle2.VelocityX = v2nAfter * nx + v2t * tx;
                //circle2.VelocityY = v2nAfter * ny + v2t * ty;

                a.velocity.Update(v1nAfter * nx + v1t * tx, v1nAfter * ny + v1t * ty);
                b.velocity.Update(v2nAfter * nx + v2t * tx, v2nAfter * ny + v2t * ty);
            }

            if (bc)
            {
                if (a.location.x >= simPanel.Bounds.Right)
                {
                    //touching right bounds
                    Console.WriteLine("Collided Right Bound");
                    a.velocity *= -1;
                }
                if (a.location.x <= simPanel.Bounds.Left)
                {
                    //touching left bounds
                    Console.WriteLine("Collided Left Bound");
                    a.velocity *= -1;
                }
                if (a.location.y <= simPanel.Bounds.Top)
                {
                    //touching top
                    Console.WriteLine("Collided Top Bound");
                    a.velocity *= -1;
                }
                if (a.location.y >= simPanel.Bounds.Bottom)
                {
                    //touching bottom
                    Console.WriteLine("Collided Bottom Bound");
                    a.velocity *= -1;
                }
            }
        }
    }
}
/*
                double newVelX1 = (a.velocity.Length() * (a.mass - b.mass) + (2 * b.mass * b.velocity.Length())) / (a.mass + b.mass);

                double newVelY1 = (a.velocity.Length() * (a.mass - b.mass) + (2 * b.mass * b.velocity.Length())) / (a.mass + b.mass);

                double newVelX2 = (b.velocity.Length() * (b.mass - a.mass) + (2 * a.mass * a.velocity.Length())) / (a.mass + b.mass);

                double newVelY2 = (b.velocity.Length() * (b.mass - a.mass) + (2 * a.mass * a.velocity.Length())) / (a.mass + b.mass);

                a.velocity.Update(newVelX1, newVelY1);
                b.velocity.Update(newVelX2, newVelY2);

*/