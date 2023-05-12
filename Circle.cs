namespace Gravity_Simulator
{
    class Circle
    {
        public Vector2 position; //top left
        public Vector2 centerLocation;
        public float radius;
        public float width;
        public float height;

        public Circle() { }

        public Circle(Vector2 position, float radius, float width, float height)
        {
            this.position = position;
            this.centerLocation = new Vector2(position.x + (width / 2), position.y + (height / 2));
            this.radius = radius;
            this.width = width;
            this.height = height;
        }

        //get center position?
        /*
        
        centerpositionX = positionX + (width / 2)
        centerpositionY = positionY + (height / 2)

        */
    }
}
