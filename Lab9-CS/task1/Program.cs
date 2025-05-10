using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = @"d:\temp\input.txt";  // Шлях до вхідного файлу
        string outputFile = @"d:\temp\output.txt"; // Шлях до вихідного файлу

        // Перевірка чи існує вхідний файл
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Вхідний файл не знайдено.");
            return;
        }

        try
        {
            // Створюємо стек для збереження чисел
            Stack<int> numbersStack = new Stack<int>();

            // Читання чисел з файлу і додавання їх в стек
            foreach (var line in File.ReadLines(inputFile))
            {
                // Перевіряємо кожну лінію на наявність чисел
                if (int.TryParse(line, out int number))
                {
                    numbersStack.Push(number); // Додаємо число в стек
                }
            }

            // Запис чисел в зворотному порядку у вихідний файл
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                while (numbersStack.Count > 0)
                {
                    writer.WriteLine(numbersStack.Pop()); // Пишемо число зі стеку в файл
                }
            }

            Console.WriteLine("Числа переписано у зворотному порядку в файл.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
        }
        Console.WriteLine("Enter...");
        Console.ReadLine();
    }
}
