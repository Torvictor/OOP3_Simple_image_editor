using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleUI;
using DrawablesUI;

namespace GraphicsEditor
{
    class WidthCommand : ICommand
    {
        Picture picture;

        public WidthCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name { get { return "width"; } }
        public string Help { get { return "Смена ширины фигуры."; } }

        public string[] Synonyms
        {
            get { return new string[] { "breadth", "w" }; }
        }

        public string Description
        {
            get
            {
                return "Изменяет ширину фигур. Сначала передается индекс фигуры " +
                    "(можно узнать с помощью команды list)\nзатем ширина, на которую её нужно изменить.";
            }
        }

        public void Execute(params string[] parameters)
        {
            int size, index;

            try
            {
                if (!Int32.TryParse(parameters[0], out index))
                {
                    Console.WriteLine("Please check the correctness of the index!");
                    return;
                }

                if (!Int32.TryParse(parameters[1], out size))
                {
                    Console.WriteLine("Please check the correctness of the size!");
                    return;
                }

                picture.Width(index, size);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
