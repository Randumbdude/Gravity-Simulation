using System;

namespace Gravity_Simulator
{
    class Collision
    {
        public static bool checkCollision(Attracter a, Attracter b)
        {
            if (Math.Pow(b.centerLocation().x - a.centerLocation().x, 2) + Math.Pow(b.centerLocation().y - a.centerLocation().y, 2) <= Math.Pow(a.circle.radius + b.circle.radius, 2))
            {
                return true;
            }
            else return false;
        }

        public static void resolveCollision(Attracter a1, Attracter a2)
        {
            double newVelX1 = (a1.speed() * (a1.mass - a2.mass) + (2 * a2.mass * a2.speed())) / (a1.mass + a2.mass);

            double newVelY1 = (a1.speed() * (a1.mass - a2.mass) + (2 * a2.mass * a2.speed())) / (a1.mass + a2.mass);

            double newVelX2 = (a2.speed() * (a2.mass - a1.mass) + (2 * a1.mass * a1.speed())) / (a1.mass + a2.mass);

            double newVelY2 = (a2.speed() * (a2.mass - a1.mass) + (2 * a1.mass * a1.speed())) / (a1.mass + a2.mass);

            a1.velocity.Update(newVelX1, newVelY1);
            a2.velocity.Update(newVelX2, newVelY2);
        }
    }
}
