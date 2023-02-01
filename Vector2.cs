using System;

namespace Gravity_Simulator
{
    struct Vector2
    {
        private double _x;
        private double _y;

        //basicly define vector
        public Vector2(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public void Update(double x, double y)
        {
            _x = x;
            _y = y;
        }

        //return vector's x and y varibles
        public double x
        {
            get
            {
                return _x;
            }
        }
        public double y
        {
            get
            {
                return _y;
            }
        }

        //add vector
        public void add(Vector2 v)
        {
            _x += v._x;
            _y += v._y;
        }

        //subtract vector
        public void sub(Vector2 v)
        {
            _x -= v._x;
            _y -= v._y;
        }
        public void sub(Vector2 v1, Vector2 v2)
        {
            _x = v1._x - v2._x;
            _y = v1._y - v2._y;
        }

        //divide other vector by float then set vector to answer
        public void div(Vector2 v, float number)
        {
            _x = v.x / number;
            _y = v.y / number;
        }

        //mulitply vector by scalar and function overloading
        public void mult(Vector2 v)
        {
            _x *= v._x;
            _y *= v._y;
        }
        public void mult(float number)
        {
            _x *= number;
            _y *= number;
        }

        //calculate magnitude of vector
        public float mag()
        {
            return (float)Math.Sqrt(_x * _x + _y * _y);
        }

        //normalize vector, in other words: converts vector to unit vector
        public void normalize()
        {
            _x = _x / mag();
            _y = _y / mag();
        }

    }
}

//https://github.com/urbnywrt/Vector/blob/master/Vector/Vector.cs