using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleUI;

namespace GraphicsEditor
{
    class EllipseCommand : ICommand
    {
        Picture picture;

        public EllipseCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name { get { return "ellipse"; } }
        public string Help { get { return "Рисование эллипса."; } }

        public string[] Synonyms
        {
            get { return new string[] { "oval", "ellipsis" }; }
        }

        public string Description
        {
            get
            {
                return "Рисование эллипса по координатам точки центра эллипса, " +
                    "по размеру осей эллипса, по градусам поворота эллипса, " + 
                    "требуется пять вещественных чисел.";
            }
        }

        public void Execute(params string[] parameters)
        {
            float x, y, horizontalAxis, verticalAxis, rotate;

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

                if (!float.TryParse(parameters[2], out horizontalAxis))
                {
                    Console.WriteLine("Please check the correctness of the horizontal axis!");
                    return;
                }

                if (!float.TryParse(parameters[3], out verticalAxis))
                {
                    Console.WriteLine("Please check the correctness of the vertical axis!");
                    return;
                }

                if (!float.TryParse(parameters[4], out rotate))
                {
                    Console.WriteLine("Please check the correctness of the rotate!");
                    return;
                }

                Ellipse ellipse = new Ellipse(x, y, horizontalAxis, verticalAxis, rotate);
                picture.Add(ellipse);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}