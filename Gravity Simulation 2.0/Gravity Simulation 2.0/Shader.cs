using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gravity_Simulation_2._0
{
    class Shader
    {
        public virtual void PreDraw(Body b, Graphics g) { }
        public virtual void Draw(Body b, Graphics g) { }
        public virtual void PostDraw(Body b, Graphics g) { }
    }

    class DefaultShader : Shader
    {
        public override void PreDraw(Body b, Graphics g)
        {
        }

        public override void Draw(Body b, Graphics g)
        {
            //g.FillEllipse(b.color, (float)b.X + Constants.xGridOffset, (float)b.Y + Constants.yGridOffset, (float)b.Radius * 2, (float)b.Radius * 2);
            g.FillEllipse(b.color, (float)b.X, (float)b.Y, (float)b.Radius * 2, (float)b.Radius * 2);
        }

        public override void PostDraw(Body b, Graphics g)
        {
        }
    }

    class VelocityShader : Shader
    {
        public static readonly SolidBrush BrushLightGray = new SolidBrush(Color.LightGray);
        public static readonly SolidBrush BrushWhite = new SolidBrush(Color.White);
        public static readonly Pen PenVelocity = new Pen(Color.Red) { Color = Color.FromArgb(50, 255, 0, 0), Width = 1, EndCap = LineCap.ArrowAnchor };

        public override void PreDraw(Body obj, Graphics g)
        {
        }

        public override void Draw(Body obj, Graphics g)
        {
            int r, gee, b;

            int vel = (int)Math.Sqrt(Math.Pow(obj.Vx, 2) + Math.Pow(obj.Vy, 2));
            Console.WriteLine(vel);

            double particleSpeed = 220 - Math.Min(vel, 220);
            ColorUtil.HsvToRgb(particleSpeed, 1, 1, out r, out gee, out b);
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, r, gee, b)), (float)obj.X, (float)obj.Y, (float)obj.Radius * 2, (float)obj.Radius * 2);
        }

        public override void PostDraw(Body obj, Graphics g)
        {
        }
    }

    public static class ColorUtil
    {
        public static void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        static int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
    }
}