using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using DrawablesUI;

namespace GraphicsEditor 
{
    public class Line : IShape
    {
        private PointF start;
        private PointF end;
        private FormatInfo format;

        public Line(float x1, float y1, float x2, float y2)
        {
            start = new PointF(x1, y1);
            end = new PointF(x2, y2);

            format = new FormatInfo();
            format.Color = Color.Black;
            format.Width = 1;
        }

        public void Draw(IDrawer drawer)
        {
            drawer.SelectPen(format.Color, format.Width);
            drawer.DrawLine(start, end);
        }

        public override string ToString()
        {
            return String.Format("Линия(Точка({0}, {1}), Точка({2}, {3}))", start.X, start.Y, end.X, end.Y);
        }

        public FormatInfo Format
        {
            get { return format; }
            set { format = value; }
        }
    }
}
