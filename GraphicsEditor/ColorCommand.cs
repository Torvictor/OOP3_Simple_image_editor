using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleUI;

namespace GraphicsEditor
{
    class ColorCommand:ICommand
    {
        Picture picture;

        public ColorCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name { get { return "color"; } }
        public string Help { get { return "Смена цвета фигуры."; } }

        public string[] Synonyms
        {
            get { return new string[] { "col", "paint" }; }
        }

        public string Description
        {
            get
            {
                return "Изменяет цвет фигур.";
            }
        }

        public void Execute(params string[] parameters)
        {
            int index;

            try
            {
                string color = parameters[1];

                if (!Int32.TryParse(parameters[0], out index))
                {
                    Console.WriteLine("Please check the correctness of the index!");
                    return;
                }

                picture.Color(index, color);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
