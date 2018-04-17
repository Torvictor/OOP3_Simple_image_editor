using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using DrawablesUI;

namespace GraphicsEditor
{
    class Ellipse : IShape
    {
        private PointF center;
        private SizeF sizes;
        private float startAngle = 0, endAngle = 360;
        private float rotate;
        private FormatInfo format;

        public Ellipse(float x, float y, float size1, float size2, 
           float rotate)
        {
            center = new PointF(x, y);
            sizes = new SizeF(size1, size2);
            this.rotate = rotate;

            format = new FormatInfo();
            format.Color = Color.Black;
            format.Width = 1;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(format.Color, format.Width);
            drawer.DrawEllipseArc(center, sizes, this.startAngle, this.endAngle, rotate);
        }

        public override string ToString()
        {
            return String.Format("Эллипс(Точка({0}, {1}), Ширина = {2}, Высота = {3})", 
                center.X, center.Y, sizes.Height, sizes.Width);
        }

        public FormatInfo Format
        {
            get { return format; }
            set { format = value; }
        }
    }
}
