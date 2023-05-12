using System;
using System.Drawing;

namespace Gravity_Simulator
{
    class Shader
    {
        public SolidBrush velocityShader(Attracter a1)
        {
            return new SolidBrush(Color.FromArgb(255, 0, 0, colorVal(a1)));
        }

        private int colorVal(Attracter a)
        {
            return Clamp(Convert.ToInt32((a.speed() * 12) * 100));
        }

        private int Clamp(int i)
        {
            if (i < 100) return 100;
            if (i > 255) return 255;
            return i;
        }
    }
}
