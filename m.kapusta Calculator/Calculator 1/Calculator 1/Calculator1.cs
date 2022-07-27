using System;

namespace Calculator_1
{
    class Calculator1
    {
        static void Main()
        {
            while (true)
            {
                double x, y;
                string action;

                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите число 1");
                    x = double.Parse(Console.ReadLine());

                    Console.WriteLine("Введите число 2");
                    y = double.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Введите корректные данные");
                    Console.ReadLine();
                    continue;
                }
                Console.WriteLine("Выберите действие:'+','-','*','/'");
                action = Console.ReadLine();


                switch (action)
                {
                    case "+":
                        Console.WriteLine(x + y);
                        break;
                    case "-":
                        Console.WriteLine(x - y);
                        break;
                    case "*":
                        if (y == 0)
                        {
                            Console.WriteLine(0);
                        }
                        else
                        {
                            Console.WriteLine(x * y);
                        }
                        break;
                    case "/":
                        if (y == 0)
                        {
                            Console.WriteLine(0);
                        }
                        else
                        {
                            Console.WriteLine(x / y);
                        }
                        break;
                    default:
                        Console.WriteLine("Ошибка!");
                        break;

                }
                Console.ReadLine();
            }


            

           

        }
    }
}
