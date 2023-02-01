namespace Gravity_Simulator
{
    class Attracter
    {
        public Vector2 otherLocation;

        public Vector2 location;
        public Vector2 velocity;
        public Vector2 acceleration;
        public float mass;
        public float otherMass;


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
            acceleration.mult(0);
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
            double G = 0.0000000000667;

            Vector2 force = new Vector2();
            force.sub(otherLocation, location);
            float distance = force.mag();
            distance = constrain(distance, 100 + 10, 500);
            force.normalize();

            double strength = (G * mass * otherMass) / (distance * distance);//(G * mass * p.mass) / (distance * distance);

            force.mult((float)strength);

            //force.mult(100000000000);
            return force;
        }
    }
}
