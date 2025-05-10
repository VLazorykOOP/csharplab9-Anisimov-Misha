using System;
using System.IO;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        string inputFile = @"d:\temp\input.txt"; // Шлях до вхідного файлу
        // Перевірка наявності файлу
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Вхідний файл не знайдено.");
            return;
        }
        try
        {
            // Створюємо дві черги: одну для символів, іншу для цифр
            Queue<char> nonDigitsQueue = new Queue<char>();
            Queue<char> digitsQueue = new Queue<char>();
            // Читання символів з файлу
            foreach (var line in File.ReadLines(inputFile))
            {
                foreach (char ch in line)
                {
                    if (char.IsDigit(ch))
                    {
                        digitsQueue.Enqueue(ch);  // Якщо цифра - додаємо до черги для цифр
                    }
                    else
                    {
                        nonDigitsQueue.Enqueue(ch); // Якщо не цифра - додаємо до черги для символів
                    }
                }
            }
            // Виведення нецифрових символів
            Console.WriteLine("Нецифрові символи:");
            while (nonDigitsQueue.Count > 0)
            {
                Console.Write(nonDigitsQueue.Dequeue()); // Друкуємо нецифрові символи
            }
            // Виведення цифр
            Console.WriteLine("\nЦифри:");
            while (digitsQueue.Count > 0)
            {
                Console.Write(digitsQueue.Dequeue()); // Друкуємо цифри
            }
            Console.WriteLine();  // Перехід на новий рядок після виведення
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
        }
        Console.WriteLine("Enter...");
        Console.ReadLine();
    }
}
