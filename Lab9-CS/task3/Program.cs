using System;
using System.Collections;
using System.IO;

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
            // Створюємо ArrayList для зберігання символів
            ArrayList allChars = new ArrayList();
            ArrayList nonDigitChars = new ArrayList();
            ArrayList digitChars = new ArrayList();

            // Читання символів з файлу
            foreach (var line in File.ReadLines(inputFile))
            {
                foreach (char ch in line)
                {
                    allChars.Add(ch);  // Додаємо всі символи до ArrayList

                    if (char.IsDigit(ch))
                    {
                        digitChars.Add(ch);  // Додаємо цифри до окремої колекції
                    }
                    else
                    {
                        nonDigitChars.Add(ch);  // Додаємо нецифрові символи
                    }
                }
            }

            // Створюємо копії колекцій за допомогою ICloneable
            ArrayList nonDigitsClone = (ArrayList)nonDigitChars.Clone();
            ArrayList digitsClone = (ArrayList)digitChars.Clone();

            // Використовуємо IComparer для сортування символів
            // Створимо клас, що реалізує IComparer
            IComparer comparer = new CharComparer();

            nonDigitChars.Sort(comparer);
            digitChars.Sort(comparer);

            // Виведення нецифрових символів
            Console.WriteLine("Нецифрові символи:");
            foreach (char ch in nonDigitChars)
            {
                Console.Write(ch);  // Друкуємо нецифрові символи
            }

            // Виведення цифр
            Console.WriteLine("\nЦифри:");
            foreach (char ch in digitChars)
            {
                Console.Write(ch);  // Друкуємо цифри
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

    // Клас для порівняння символів
    public class CharComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            // Порівнюємо символи за їх значенням
            if (x is char cx && y is char cy)
            {
                return cx.CompareTo(cy);
            }
            else
            {
                throw new ArgumentException("Обидва об'єкти повинні бути символами");
            }
        }
    }
}
