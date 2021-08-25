using System;

namespace Module9Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions = new Exception[5];
            exceptions[0] = new Exception();
            try
            {

            }
            catch(ArgumentNullException) // Исключение №1
            {
                Console.WriteLine("Поле не может быть пустым...");
            }
            catch (ArrayTypeMismatchException ex) // Исключение №2
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }
        static void Method()
        {

        }
        static (string, string, int, double, double, double, double) Anketa()
        {
            (string name, string surname, byte age, double mathscore, double engscore, double totalscore) anketa;
            anketa.name = Console.ReadLine();
            anketa.surname = Console.ReadLine();
            if(anketa.name.Length < 2 || anketa.surname.Length < 2)
            {
                Exception shortname = new Exception("Имя/фамилия должны состоять минимум из двух букв");
                throw shortname;
            }
            foreach (var letter in anketa.name)
            {
                if (!Char.IsLetter(letter)) throw new ArrayTypeMismatchException("Имя/фамилия должны иметь только буквы");
            }
            foreach (var letter in anketa.surname)
            {
                if (!Char.IsLetter(letter)) throw new ArrayTypeMismatchException("Имя/фамилия должны иметь только буквы");
            }
            anketa.age = Convert.ToByte(Console.ReadLine());

        }

        static double MathTest()
        {
            Console.WriteLine("Вас ожидают три вопроса по математике, каждый дает разное количество баллов");
            Console.WriteLine("1. (4 балла) Среднее геометрическое чисел а и b: меньше или равно среднему квадратичному a и b (вариант 1);\nменьше или равно среднему гармоническому a и b (вариант 2)?");
            Console.WriteLine("2. (5 баллов) Что больше, 2 * lg 320 или 3 * ln 7.84 ? (Введите 1 или 2)");
            Console.WriteLine("3. (6 баллов) Неопределенный интеграл от tg x равен: -sin(ln x) + C (вариант 1); -ln(cos x) + С (вариант 2)?");
            Console.Write("1. ");
            Console.ReadLine()
        }
        static double EnglishTest()
        {

        }
        static int Score(int collect)
        {

        }
    }
}
