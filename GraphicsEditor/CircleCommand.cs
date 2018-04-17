using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleUI;

namespace GraphicsEditor
{
    class CircleCommand : ICommand
    {
        Picture picture;

        public CircleCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name { get { return "circle"; } }
        public string Help { get { return "Рисование окружности."; } }

        public string[] Synonyms
        {
            get { return new string[] { "range", "ring" }; }
        }

        public string Description
        {
            get
            {
                return "Рисование окружности по координатам точки центра круга и " +
                    "радиусу, требуется три вещественных числа.";
            }
        }

        public void Execute(params string[] parameters)
        {
            float x, y, radius;

            try
            {
                if (!float.TryParse(parameters[0], out x))
                {
                    Console.WriteLine("Please check the correctness of the X!");
                    return;
                }

                if (!float.TryParse(parameters[1], out y))
                {
                    Console.WriteLine("Please check the correctness of the Y!");
                    return;
                }

                if (!float.TryParse(parameters[2], out radius))
                {
                    Console.WriteLine("Please check the correctness of the radius!");
                    return;
                }

                Circle circle = new Circle(x, y, radius);
                picture.Add(circle);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
