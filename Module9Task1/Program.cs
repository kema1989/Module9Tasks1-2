using System;
using System.Collections.Generic;

namespace Module9Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Method();
        }
        static void Method()
        {
            var exceptions = new[] { new Exception(), new ArgumentNullException(), new ArrayTypeMismatchException(), new DivideByZeroException(), new IndexOutOfRangeException() };
            foreach (var item in exceptions)
            {
                try
                {
                    Survey();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Нельзя передавать пустую строку...");
                    Method();
                }
                catch (ArrayTypeMismatchException ex)
                {
                    Console.WriteLine(ex.Message);
                    Method();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено значение неверного формата");
                    Method();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Запрашиваемый номер выходит за границы допустимых номеров");
                    Method();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Method();
                }
            }
        }
        static void Survey()
        {
            (byte age, string name, string surname, string opinion, string gift) anketa;
            Console.WriteLine("Предлагаем ответить на 1 вопрос и получить подарок!");
            
            Console.WriteLine("Введите ваш возраст");
            anketa.age = Convert.ToByte(Console.ReadLine());
            if(anketa.age < 18)
            {
                throw new Exception("Возраст должен быть больше 18");
            }

            Console.WriteLine("Введите ваше имя");
            anketa.name = Console.ReadLine();
            if (anketa.name.Length < 2)
            {
                throw new Exception("Имя должно состоять минимум из двух букв");
            }
            foreach (var letter in anketa.name)
            {
                if (!Char.IsLetter(letter)) throw new ArrayTypeMismatchException("Имя должно состоять только из букв");
            }

            Console.WriteLine("Введите вашу фамилию");
            anketa.surname = Console.ReadLine();
            if(anketa.surname.Length < 2)
            {
                throw new Exception("Фамилия должна состоять минимум из двух букв");
            }
            foreach (var letter in anketa.surname)
            {
                if (!Char.IsLetter(letter)) throw new ArrayTypeMismatchException("Фамилия должна состоять только из букв");
            }

            Console.WriteLine("Напишите ваше мнение о продукции компании Apple, в частности о планшетах Apple iPad. Актуально ли их использование?");
            anketa.opinion = Console.ReadLine();
            if(anketa.opinion.Length < 5)
            {
                throw new Exception("Ответ на вопрос должен быть не короче 5 символов...");
            }

            string[] gifts = new string[3] { "Скидка 5% на покупку iPad", "Чехол-книжка на iPad 2020 10.2''", "Зарядное устройство 18W для iPad" };
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Выберите подарок из предложенных (введите его номер)");
            foreach(var gift in gifts)
            {
                Console.WriteLine(gift);
            }
            Console.ResetColor();
            byte key = Convert.ToByte(Console.ReadLine());
            anketa.gift = gifts[key - 1];
            Console.WriteLine($"Выбран подарок номер {key}: {anketa.gift}");
            Console.WriteLine("Спасибо за отзыв, насчет подарка мы пошутили, не дождетесь! XD");
        }
    }
}
