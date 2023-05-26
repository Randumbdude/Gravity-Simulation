using System.Collections.Generic;

namespace BHT_Method
{
    public class Quad
    {
        public Vector2 CenterOfMass { get; set; }
        public double TotalMass { get; set; }
        public Vector2 CenterOfMassTimesTotalMass { get; set; }
        public Quad[] Children { get; set; }
        public List<Body> Bodies { get; set; } // Add a List to store the bodies within the quad

        public Quad()
        {
            CenterOfMass = new Vector2(0, 0);
            TotalMass = 0;
            CenterOfMassTimesTotalMass = new Vector2(0, 0);
            Children = new Quad[4];
            Bodies = new List<Body>(); // Initialize the list of bodies
        }

        public bool IsLeaf()
        {
            return Children[0] == null;
        }
    }
}
