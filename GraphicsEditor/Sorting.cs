using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class Sorting
    {
        //сортировка Шелла над списком целых чисел:
        public void ShellMethod(List<int> list)
        {
            int curr;//элемент для обмена переменных
            int step;//шаг разбиения массива

            for (step = list.Count / 2; step > 0; step = step / 2)
            {
                for (int i = step; i < list.Count; i++)
                {
                    for (int j = i - step; j >= 0; j = j - step)
                    {
                        if (list[j] > list[j + step])
                        {
                            curr = list[j];
                            list[j] = list[j + step];
                            list[j + step] = curr;
                        }
                    }
                }
            }
        }
    }
}
