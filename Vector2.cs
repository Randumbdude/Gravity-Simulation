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

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return left.x != right.x || left.y != right.y;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2 { _x = left.x + right.x, _y = left.y + right.y };
        }

        public static Vector2 operator +(Vector2 left, float right)
        {
            return new Vector2 { _x = left.x + right, _y = left.y + right };
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2 { _x = left.x - right.x, _y = left.y - right.y };
        }

        public static Vector2 operator -(Vector2 v1)
        {
            return new Vector2 { _x = -v1.x, _y = -v1.y };
        }

        public static Vector2 operator -(Vector2 left, float right)
        {
            return new Vector2 { _x = left.x - right, _y = left.y - right };
        }

        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2 { _x = left.x * right.x, _y = left.y * right.y };
        }

        public static Vector2 operator *(Vector2 left, float right)
        {
            return new Vector2 { _x = left.x * right, _y = left.y * right };
        }

        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            return new Vector2 { _x = left.x / right.x, _y = left.y / right.y };
        }

        public static Vector2 operator /(Vector2 left, float right)
        {
            return new Vector2 { _x = left.x / right, _y = left.y / right };
        }

        public static double DotProduct(Vector2 left, Vector2 right)
        {
            return left.x * right.x + left.y * right.y;
        }

        public double Length()
        {
            return (double)Math.Sqrt(_x * _x + _y * _y);
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

        public int getQuadrant()
        {
            int quadrant = 1;

            bool xpositive = x > 0;
            bool ypositive = y > 0;

            if (xpositive && ypositive)
            {
                quadrant = 1;
            }
            else if (!xpositive && ypositive)
            {
                quadrant = 2;
            }
            else if (!xpositive && !ypositive)
            {
                quadrant = 3;
            }
            else if (xpositive && !ypositive)
            {
                quadrant = 4;
            }

            return quadrant;
        }
    }
}

//https://github.com/urbnywrt/Vector/blob/master/Vector/Vector.cs
//https://github.com/dankelley2/sharpPhysics/blob/9042c4f9933a6c23551861105718aa017c86da8b/physics/Engine/Structs/Vec2.cs