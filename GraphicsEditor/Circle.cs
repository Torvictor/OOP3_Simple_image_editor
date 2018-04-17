using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using DrawablesUI;

namespace GraphicsEditor
{
    class Circle : IShape
    {
        private PointF center;
        private SizeF sizes;
        private FormatInfo format;

        public Circle(float x, float y, float radius)
        {
            center = new PointF(x, y);
            sizes = new SizeF(radius, radius);
            
            format = new FormatInfo();
            format.Color = Color.Black;
            format.Width = 1;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(format.Color, format.Width);
            drawer.DrawEllipseArc(center, sizes);
        }

        public override string ToString()
        {
            return String.Format("Круг(Точка({0}, {1}), Радиус = {2})", center.X, center.Y, sizes.Width);
        }

        public FormatInfo Format
        {
            get { return format; }
            set { format = value;} 
        }
    }
}
