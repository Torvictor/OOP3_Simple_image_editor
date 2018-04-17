using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleUI;

namespace GraphicsEditor
{
    class RemoveCommand : ICommand
    {
        Picture picture;

        public RemoveCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name { get { return "remove"; } }
        public string Help { get { return "Удаление фигуры."; } }

        public string[] Synonyms
        {
            get { return new string[] { "delete", "del" }; }
        }

        public string Description
        {
            get
            {
                return "Удаление фигуры по индексу. Если индекс превышает кол-во фигур или\n"+
                "отрицательный, то соответствующая фигура не удаляется!";
                       
            }
        }

        public void Execute(params string[] parameters)
        {
            picture.Remove(parameters);
        }
    }
}
