using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using ConsoleUI;

namespace GraphicsEditor
{
    class LineCommand : ICommand
    {
        Picture picture;

        public LineCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name { get { return "line"; } }
        public string Help { get { return "Рисование отрезка."; } }

        public string[] Synonyms
        {
            get { return new string[] { "straight", "section" }; }
        }

        public string Description
        {
            get { return "Рисование отрезка по координатам точек "+ 
                "начала и конца отрезка, требуется четыре вещественных числа."; }
        }

        public void Execute(params string[] parameters)
        {
            float x1, y1, x2, y2;

            try
            {
                if (!float.TryParse(parameters[0], out x1))
                {
                    Console.WriteLine("Please check the correctness of the X1!");
                    return;
                }

                if (!float.TryParse(parameters[1], out y1))
                {
                    Console.WriteLine("Please check the correctness of the Y1!");
                    return;
                }

                if (!float.TryParse(parameters[2], out x2))
                {
                    Console.WriteLine("Please check the correctness of the X2!");
                    return;
                }

                if (!float.TryParse(parameters[3], out y2))
                {
                    Console.WriteLine("Please check the correctness of the Y2!");
                    return;
                }

                Line line = new Line(x1, y1, x2, y2);
                picture.Add(line);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
