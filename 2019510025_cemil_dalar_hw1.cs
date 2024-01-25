using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalsın_burada
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;

            Console.WriteLine("please enter the value of x");
            x = Convert.ToDouble(Console.ReadLine());
            while (x > 25 || x < 0)
            {
                Console.WriteLine("error,please enter the value of x again , value of x can be 0<x<25.");
                x = Convert.ToInt32(Console.ReadLine());
            }
            char operation;
            Console.WriteLine("please choose the type of the operator  multiplying(*) or dividing(/)");
            operation = Convert.ToChar(Console.ReadLine());
            while (operation != '*' && operation != '/')
            {
                Console.WriteLine("error,please choose the operation again,the operator can be (*) or (/)");
                operation = Convert.ToChar(Console.ReadLine());
            }
            double coefficient_of_X, d, e;
            double result = 0;
            for (double t = 1; t <= 30; t++)
            {
                //first, I'm trying to find the numerator
                //numerator 
                coefficient_of_X = 4 * t - 1;
                double power_of_x = 1;
                for (int k = 1; k <= 3 * t - 1; k++)
                {
                    power_of_x = power_of_x * x;
                        
                }
                 e = power_of_x * coefficient_of_X;
                //I'm trying to find  factorial.
                double factorial = 1;

                for (int i = 1; i <= 2 * t + 2; i++)
                {
                    factorial = factorial*i;
                }                             
                double min;
                double numerator;
                
                if (e < factorial)
                {
                    min = e;
                }
                else
                {
                    min = factorial;
                }
                d = 5 * t - 3;
                //I wrote an IF statement according to the operator that the user will choose.
                if (operation == '/')
                    numerator = min / d;
                else
                    numerator = min * d;
                //second, I'm trying to find a denominator.
                double denominator = 0;
                double bases;
                for (double m = 1; m <= t + 1; m++)
                {
                    double sum = 1;
                    for (double n = 1; n <= t + 1; n++)
                    {
                        bases = 2 * (t + m - 1);
                        sum = sum * bases;
                    }
                    denominator += sum;
                }
               
                if (t % 2 == 0)
                {
                    result -= numerator / denominator;

                }
                else
                {
                    result += numerator / denominator;

                }


            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("the result is="+result);
            Console.ReadLine();
           
        }
    }
}
