using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gravity_Simulator
{
    class Shader
    {
        public virtual void PreDraw(Attracter a, Graphics g) { }
        public virtual void Draw(Attracter a, Graphics g) { }
        public virtual void PostDraw(Attracter a, Graphics g) { }
    }

    class ShaderDefault : Shader
    {
        public override void PreDraw(Attracter a, Graphics g)
        {
        }

        public override void Draw(Attracter a, Graphics g)
        {
            g.FillEllipse(a.Color, (float)a.location.x + grid.xgridOffset, (float)a.location.y + grid.ygridOffset, a.circle.width, a.circle.height);
        }

        public override void PostDraw(Attracter a, Graphics g)
        {
        }
    }

    class InfoShader : Shader
    {
        private static readonly Pen PenBlue = new Pen(Color.Blue);
        private static readonly Pen PenVelocity = new Pen(Color.Red) { Color = Color.FromArgb(200, 255, 0, 0), Width = 2, EndCap = LineCap.ArrowAnchor };

        Font debugFont = new Font(FontFamily.GenericMonospace, 10);
        SolidBrush debugBrush = new SolidBrush(Color.WhiteSmoke);

        int statOffset = 45;

        public override void PreDraw(Attracter a, Graphics g)
        {
            g.DrawRectangle(PenBlue, (float)a.location.x + grid.xgridOffset, (float)a.location.y + grid.ygridOffset, a.circle.width, a.circle.height);
        }

        public override void Draw(Attracter a, Graphics g)
        {
            g.FillEllipse(a.Color, (float)a.location.x + grid.xgridOffset, (float)a.location.y + grid.ygridOffset, a.circle.width, a.circle.height);
            g.DrawLine(PenVelocity, (float)a.centerLocation().x + grid.xgridOffset, (float)a.centerLocation().y + grid.ygridOffset, (float)(a.centerLocation().x + a.velocity.x * 10) + grid.xgridOffset, (float)(a.centerLocation().y + a.velocity.y * 10) + grid.ygridOffset);
        }

        public override void PostDraw(Attracter a, Graphics g)
        {
            g.DrawString($"{a.Name} Cords: (X:{a.location.x}, Y:{a.location.y}) SPEED: {a.speed()}", debugFont, debugBrush, new PointF(0, statOffset));
            statOffset += 15;
        }
    }
}