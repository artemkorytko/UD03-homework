using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    class Calculator2
    {
        static void Main()
        {
            char[] actions = { '+', '-', '*', '/' };
            string example;
            char sign = ' ';
            int signindex = 0;

            Console.WriteLine("Введите пример:");
            example = Console.ReadLine();
            


            for (int i = 0; i < example.Length; i++)
            {
                if (actions.Contains(example[i])) 
                {
                    sign = example[i];
                    signindex = i;

                }
            }
            if(signindex == 0)
            {
                Console.WriteLine("Ошибка!Не указана операция!");
                Console.ReadLine();
                return;
            }

            double value1;
            double value2;
            double result = 0;


            string sub;
            sub = example.Substring(0, signindex);
            if (double.TryParse(sub, out double parseResult1))
            {
                value1 = parseResult1;
            }
            else
            {
                Console.WriteLine("Ведите цифровое значение!");
                Console.ReadLine();
                return;
            }
            sub = example.Substring(signindex + 1);
            if (double.TryParse(sub, out double parseResult2))
            {
                value2 = parseResult2;
            }
            else
            {
                Console.WriteLine("Ведите цифровое значение!");
                Console.ReadLine();
                return;
            }
            
            switch (sign)
            {
                case '+':
                    result = value1 + value2;
                    break;
                case '-':
                    result = value1 - value2;
                    break;
                case '*':
                    result = value1 * value2;
                    break;
                case '/':
                    if (value2 == 0)
                    {
                        Console.WriteLine("На ноль делить нельзя!");
                    }
                    else
                    {
                        result = value1 / value2;
                    }
                    break;
                default:
                    Console.WriteLine("Нет такой операции!");
                    break;
            }
            Console.WriteLine($"Результат вычисления равен: {result}");
            Console.ReadLine();
        }
    }  
}
