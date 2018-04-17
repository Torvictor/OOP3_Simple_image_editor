using System;
using System.Collections.Generic;
using DrawablesUI;
using System.Drawing;

namespace GraphicsEditor
{
    public class Picture : IDrawable
    {
        private readonly List<IDrawable> shapes = new List<IDrawable>();
        private readonly object lockObject = new object();

        public event Action Changed;

        public void Remove(IDrawable shape)
        {
            lock (lockObject)
            {
                shapes.Remove(shape);
            }
        }

        public void RemoveAt(int index)
        {
            lock (lockObject)
            {
                shapes.RemoveAt(index);
                if (Changed != null)
                    Changed();
            }
        }

        public void Add(IDrawable shape)
        {
            lock (lockObject)
            {
                shapes.Add(shape);
                if (Changed != null)
                    Changed();
            }
        }

        public void Add(int index, IDrawable shape)
        {
            lock (lockObject)
            {
                shapes.Insert(index, shape);
                if (Changed != null)
                    Changed();
            }
        }

        public void Draw(IDrawer drawer)
        {
            lock (lockObject)
            {
                foreach (var shape in shapes)
                {
                    shape.Draw(drawer);
                }
            }
        }

        public void List()
        {
            for (var i = 0; i < shapes.Count; i++)
            {
                Console.Write("[" + i + "] ");
                Console.WriteLine(shapes[i].ToString());
            }
        }

        public void Remove(params string[] parameters)
        {
            if (shapes.Count == 0)
                return;

            int elem;
            List<int> numbers = new List<int>(); 

            foreach (var param in parameters)
            {
                if (Int32.TryParse(param, out elem))
                {
                    if (elem >= 0 && elem < shapes.Count)
                    {
                        numbers.Add(elem);
                    }
                }
            }

            Sorting start = new Sorting();
            start.ShellMethod(numbers);

            for (int n = numbers.Count - 1; n >= 0 ; n--)
            {
                  Console.WriteLine(numbers[n]);
                  RemoveAt(numbers[n]);
            }
        }

        public bool Width(int index, int size)
        {
            if (index >= shapes.Count || index < 0)
                return false;

            var picture = shapes[index];
            ((IShape)picture).Format.Width = size;
            RemoveAt(index);
            Add(picture);
            return true;
        }

        public bool Color(int index, string color)
        {
            if (index >= shapes.Count || index < 0)
                return false;

            var picture = shapes[index];
            try
            {
               ((IShape)picture).Format.Color = ColorTranslator.FromHtml(color);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            RemoveAt(index);
            Add(picture);
            return true;
        }
    }
}