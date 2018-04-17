using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleUI;

namespace GraphicsEditor
{
    class PointCommand : ICommand
    {
        Picture picture;

        public PointCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name { get { return "point"; } }
        public string Help { get { return "Рисование точки."; } }

        public string[] Synonyms
        {
            get { return new string[] { "dot", "pt" }; }
        }

        public string Description
        {
            get
            {
                return "Рисование точки по координате, требуется два вещественных числа.";
            }
        }

        public void Execute(params string[] parameters)
        {
            float x, y;
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

                Point point = new Point(x, y);
                picture.Add(point);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}