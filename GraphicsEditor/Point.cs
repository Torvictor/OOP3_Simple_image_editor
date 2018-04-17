using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using DrawablesUI;

namespace GraphicsEditor
{
    public class Point : IShape
    {
        private PointF point;
        private FormatInfo format;

        public Point(float x, float y)
        {
            point = new PointF(x, y);

            format = new FormatInfo();
            format.Color = Color.Black;
            format.Width = 1;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(format.Color, format.Width);
            drawer.DrawPoint(point);
        }

        public override string ToString()
        {
            return String.Format("Точка({0}, {1})", point.X, point.Y);
        }

        public FormatInfo Format
        {
            get { return format; }
            set { format = value; }
        }
    }
}