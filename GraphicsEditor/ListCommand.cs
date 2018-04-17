using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleUI;

namespace GraphicsEditor
{
    class ListCommand : ICommand
    {
        Picture picture;

        public ListCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name { get { return "list"; } }
        public string Help { get { return "Вывод списка фигур."; } }

        public string[] Synonyms
        {
            get { return new string[] { "ls", "view" }; }
        }

        public string Description
        {
            get
            {
                return "Вывод списка всех имеющихся фигур. ";
            }
        }

        public void Execute(params string[] parameters)
        {
            picture.List();
        }
    }
}
