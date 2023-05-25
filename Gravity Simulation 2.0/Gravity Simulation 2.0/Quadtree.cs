using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravity_Simulation_2._0
{
    class Quadtree
    {
        private const int MaxDepth = 10;
        private const int Threshold = 4;

        private double minX, minY, maxX, maxY;
        private List<Body> bodies;
        private Quadtree[] children;

        public Quadtree(double minX, double minY, double maxX, double maxY)
        {
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
            bodies = new List<Body>();
            children = null;
        }

        public void Insert(Body body)
        {
            if (children != null)
            {
                int quadrant = GetQuadrant(body.X, body.Y);
                if (quadrant != -1)
                {
                    children[quadrant].Insert(body);
                    return;
                }
            }

            bodies.Add(body);

            if (bodies.Count > Threshold && children == null)
            {
                Subdivide();
                foreach (var b in bodies)
                {
                    int quadrant = GetQuadrant(b.X, b.Y);
                    if (quadrant != -1)
                    {
                        children[quadrant].Insert(b);
                    }
                }

                bodies.Clear();
            }
        }

        private void Subdivide()
        {
            double midX = (minX + maxX) / 2;
            double midY = (minY + maxY) / 2;

            children = new Quadtree[4];
            children[0] = new Quadtree(minX, minY, midX, midY);
            children[1] = new Quadtree(midX, minY, maxX, midY);
            children[2] = new Quadtree(minX, midY, midX, maxY);
            children[3] = new Quadtree(midX, midY, maxX, maxY);
        }

        private int GetQuadrant(double x, double y)
        {
            if (x < minX || x >= maxX || y < minY || y >= maxY)
            {
                return -1;
            }

            double midX = (minX + maxX) / 2;
            double midY = (minY + maxY) / 2;

            if (x < midX)
            {
                if (y < midY)
                {
                    return 0;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                if (y < midY)
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
        }

        public void CalculateForce(Body body, double theta, double G)
        {
            if (children != null)
            {
                double distance = Math.Sqrt((body.X - (minX + maxX) / 2) * (body.X - (minX + maxX) / 2) +
                                            (body.Y - (minY + maxY) / 2) * (body.Y - (minY + maxY) / 2));
                double width = maxX - minX;
                double height = maxY - minY;

                if (width / distance < theta)
                {
                    // Approximate the forces from the bodies in this region
                    foreach (var b in bodies)
                    {
                        if (b != body)
                        {
                            double dx = b.X - body.X;
                            double dy = b.Y - body.Y;
                            double distSquared = dx * dx + dy * dy;
                            double force = (G * b.Mass) / (distSquared * Math.Sqrt(distSquared));
                            body.Vx += force * dx;
                            body.Vy += force * dy;
                        }
                    }
                }
                else
                {
                    // Traverse child nodes to calculate forces
                    foreach (var child in children)
                    {
                        child.CalculateForce(body, theta, G);
                    }
                }
            }
        }
    }
}
