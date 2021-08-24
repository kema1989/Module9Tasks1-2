using System;

namespace Module9Task2
{
    class Program
    {
        public delegate void ShowArrayDelegate(string[] array);
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    NumberReader numberReader = new NumberReader();
                    string[] array 
                    int number = numberReader.Read();
                    numberReader.NumberEnteredEvent += Show;



                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Фамилия не может состоять менее, чем из двух букв");
                }
                catch (ArrayTypeMismatchException)
                {
                    Console.WriteLine("Фамилия должна состоять только из букв");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
            }
        }
        static void Show(int number, string[] array)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("Выбрана сортировка от А до Я");
                    SortAscend(array);
                    break;
                case 2:
                    Console.WriteLine("Выбрана сортировка от Я до А");
                    SortDescend(array);
                    break;
            }
        }
        

        static void SortAscend(string[] array)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < array.Length - 1; ++i)
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        string buf = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = buf;
                        flag = true;
                    }
            }
            foreach (string lastname in array)
                Console.WriteLine(lastname);
        }
        static void SortDescend(string[] array)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < array.Length - 1; ++i)
                    if (array[i].CompareTo(array[i + 1]) < 0)
                    {
                        string buf = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = buf;
                        flag = true;
                    }
            }
            foreach (string s in array)
                Console.WriteLine("{0} ", s);
        }
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number, string[] array);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public int Read()
        {
            Console.WriteLine("Для того, чтобы отсортировать список в формате А-Я, введите \"1\",\nдля сортировки в формате Я-А введите \"2\"");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2) throw new FormatException();
            return number;

        }
        static string[] LastNames()
        {
            string[] array = new string[5];
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.WriteLine($"Введите фамилию номер {i + 1}");
                array[i] = Console.ReadLine();
                if (array[i].Length < 2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                foreach (var letter in array[i])
                {
                    if (!Char.IsLetter(letter)) throw new ArrayTypeMismatchException();
                }
            }
            return array;
        }
        protected virtual void NumberEntered(int number, string[] array)
        {
            NumberEnteredEvent?.Invoke(number, LastNames());
        }
    }
}
