using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введiть шлях до вхiдного файлу:");
        string inputFile = Console.ReadLine();

        // Зчитування вмісту вхідного файлу
        string inputExpression = File.ReadAllText(inputFile);

        // Обчислення виразу методом Рутисхаузера
        int result = EvaluateRPN(inputExpression);

        // Формування назви вихідного файлу
        string outputFile = Path.GetFileNameWithoutExtension(inputFile) + ".res";

        // Запис результату у вихідний файл
        File.WriteAllText(outputFile, result.ToString());

        Console.WriteLine($"Результат обчислення збережено у файлi: {outputFile}");
    }

    static int EvaluateRPN(string expression)
    {
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];

            if (Char.IsDigit(c))
            {
                stack.Push((int)Char.GetNumericValue(c));
            }
            else if (c == '+' || c == '-')
            {
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();
                int result;

                if (c == '+')
                {
                    result = operand1 + operand2;
                }
                else
                {
                    result = operand1 - operand2;
                }

                stack.Push(result);
            }
        }

        return stack.Pop();
    }
}
