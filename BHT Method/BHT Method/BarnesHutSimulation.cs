using System;

namespace BHT_Method
{
    public class BarnesHutSimulation
    {
        private const double G = 6.674e-11; // Gravitational constant

        private Quad root;

        public BarnesHutSimulation()
        {
            root = new Quad();
        }

        public void AddBody(Body body)
        {
            Insert(root, body);
        }

        private void Insert(Quad quad, Body body)
        {
            if (quad.IsLeaf())
            {
                if (quad.TotalMass == 0)
                {
                    quad.CenterOfMass = body.Position;
                    quad.TotalMass = body.Mass;
                    quad.CenterOfMassTimesTotalMass = body.Position.Multiply(body.Mass);
                }
                else
                {
                    Vector2 centerOfMassTimesTotalMass = quad.CenterOfMassTimesTotalMass.Add(body.Position.Multiply(body.Mass));
                    quad.CenterOfMass = centerOfMassTimesTotalMass.Multiply(1.0 / (quad.TotalMass + body.Mass));
                    quad.TotalMass += body.Mass;
                    quad.CenterOfMassTimesTotalMass = centerOfMassTimesTotalMass;
                }

                quad.Bodies.Add(body); // Add the body to the quad's list of bodies
            }
            else
            {
                int quadrant = GetQuadrant(quad.CenterOfMass, body.Position);
                if (quad.Children[quadrant] == null)
                {
                    quad.Children[quadrant] = new Quad();
                }

                Insert(quad.Children[quadrant], body);

                Vector2 centerOfMassTimesTotalMass = quad.CenterOfMassTimesTotalMass.Add(body.Position.Multiply(body.Mass));
                quad.CenterOfMass = centerOfMassTimesTotalMass.Multiply(1.0 / (quad.TotalMass + body.Mass));
                quad.TotalMass += body.Mass;
                quad.CenterOfMassTimesTotalMass = centerOfMassTimesTotalMass;
            }
        }

        public void Simulate(double timeStep)
        {
            UpdateForces(root);
            UpdateBodies(root, timeStep);
        }

        private void UpdateForces(Quad quad)
        {
            if (quad.IsLeaf())
            {
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                Quad child = quad.Children[i];
                if (child == null)
                {
                    continue;
                }

                UpdateForces(child);

                quad.CenterOfMassTimesTotalMass = quad.CenterOfMassTimesTotalMass.Add(child.CenterOfMassTimesTotalMass);
                quad.TotalMass += child.TotalMass;

                double dx = child.CenterOfMass.X - quad.CenterOfMass.X;
                double dy = child.CenterOfMass.Y - quad.CenterOfMass.Y;
                double distanceSquared = dx * dx + dy * dy;

                double combinedSize = Math.Max(Math.Abs(quad.CenterOfMass.X - child.CenterOfMass.X), Math.Abs(quad.CenterOfMass.Y - child.CenterOfMass.Y));

                if (combinedSize * combinedSize < distanceSquared)
                {
                    double force = G * quad.TotalMass * child.TotalMass / distanceSquared;
                    double angle = Math.Atan2(dy, dx);

                    quad.CenterOfMass = quad.CenterOfMass.Add(new Vector2(Math.Cos(angle) * force, Math.Sin(angle) * force));
                }
            }
        }

        private void UpdateBodies(Quad quad, double timeStep)
        {
            if (quad.IsLeaf())
            {
                for (int i = 0; i < quad.Bodies.Count; i++)
                {
                    Body body = quad.Bodies[i];

                    Vector2 netForce = CalculateNetForce(quad, body);
                    Vector2 acceleration = netForce.Multiply(1.0 / body.Mass);

                    // Update velocity
                    body.Velocity = body.Velocity.Add(acceleration.Multiply(timeStep));

                    // Update position
                    body.Position = body.Position.Add(body.Velocity.Multiply(timeStep));

                    //collisions
                    //if (CheckCollision(bodies[i], bodies[j]))
                    //{
                    //    ResolveCollision(bodies[i], bodies[j]);
                    //}
                }
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                Quad child = quad.Children[i];
                if (child != null)
                {
                    UpdateBodies(child, timeStep);
                }
            }
        }

        private Vector2 CalculateNetForce(Quad quad, Body body)
        {
            if (quad.IsLeaf() || quad.CenterOfMass.Subtract(body.Position).Magnitude() < 1e-6)
            {
                // If quad is a leaf or body is too close to quad's center of mass, approximate force directly
                Vector2 force = new Vector2(0, 0);
                foreach (var otherBody in quad.Bodies)
                {
                    if (otherBody != body)
                    {
                        Vector2 direction = otherBody.Position.Subtract(body.Position);
                        double distance = direction.Magnitude();
                        double forceMagnitude = (G * body.Mass * otherBody.Mass) / (distance * distance * distance);
                        force = force.Add(direction.Multiply(forceMagnitude));
                    }
                }
                return force;
            }
            else
            {
                // Calculate net force from children quads
                Vector2 force = new Vector2(0, 0);
                for (int i = 0; i < 4; i++)
                {
                    Quad child = quad.Children[i];
                    if (child != null)
                    {
                        Vector2 direction = child.CenterOfMass.Subtract(body.Position);
                        double distance = direction.Magnitude();
                        double forceMagnitude = (G * body.Mass * child.TotalMass) / (distance * distance * distance);
                        force = force.Add(direction.Multiply(forceMagnitude));
                    }
                }
                return force;
            }
        }

        private bool CheckCollision(Body body1, Body body2)
        {
            double dx = body2.Position.X - body1.Position.X;
            double dy = body2.Position.Y - body1.Position.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            return distance < (body1.Radius + body2.Radius);
        }

        private void ResolveCollision(Body body1, Body body2)
        {
            double dx = body2.Position.X - body1.Position.X;
            double dy = body2.Position.Y - body1.Position.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            double nx = dx / distance;
            double ny = dy / distance;

            double dvx = body2.Velocity.X - body1.Velocity.X;
            double dvy = body2.Velocity.Y - body1.Velocity.Y;

            double normalSpeed = dvx * nx + dvy * ny;

            if (normalSpeed >= 0) // Bodies are moving apart
                return;

            double impulse = (2 * normalSpeed) / (body1.Mass + body2.Mass);

            body1.Velocity.X += impulse * body2.Mass * nx;
            body1.Velocity.Y += impulse * body2.Mass * ny;
            body2.Velocity.X -= impulse * body1.Mass * nx;
            body2.Velocity.Y -= impulse * body1.Mass * ny;
        }

        private int GetQuadrant(Vector2 centerOfMass, Vector2 position)
        {
            if (position.X <= centerOfMass.X && position.Y <= centerOfMass.Y)
                return 0; // bottom left quadrant
            else if (position.X <= centerOfMass.X && position.Y > centerOfMass.Y)
                return 1; // top left quadrant
            else if (position.X > centerOfMass.X && position.Y <= centerOfMass.Y)
                return 2; // bottom right quadrant
            else
                return 3; // top right quadrant
        }
    }
}
