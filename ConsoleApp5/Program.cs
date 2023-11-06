using System;
using ClassLibrary5;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] indexes = new string[] {
                "12345",
                "10007",
                "98765",
                "01090",
                "M4E",
                "23552",
                "01127",
                "84135",
                "28300",
                "246020",
                "HM 01"
            };
            string[] countries = new string[] {
                "Россия",
                "США",
                "Россия",
                "Франция",
                "Канада",
                "Франция",
                "Германия",
                "Италия",
                "Испания",
                "Беларусь",
                "Бермуды"
            };

            string inputText = "";

            AddressExtractor extractor = new AddressExtractor(indexes, countries);

            int choice = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("|=====================================|");
                Console.WriteLine("|          Выберите действие:         |");
                Console.WriteLine("|=====================================|");
                Console.WriteLine("|     1. Вывести введенный текст      |");
                Console.WriteLine("|   2.Вывести отсортированные данные  |");
                Console.WriteLine("|=====================================|");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат ввода. Пожалуйста, введите число.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(inputText))
                {
                    Console.WriteLine("Введенный текст отсутствует или состоит только из пробельных символов.");
                    Console.WriteLine("Введите текст с индексами стран:");
                    inputText = Console.ReadLine();

                    Console.WriteLine("Нажмите Enter для продолжения...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Введенный текст:\n{inputText}\n");
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        int rightPadding = 34;
                        int leftPadding = 17;
                        Console.WriteLine("|" + new string('-', 56) + "|");
                        Console.WriteLine("| {0,-" + leftPadding + "} | {1,-" + rightPadding + "} |", "Индекс", "Страна");
                        Console.WriteLine("|" + new string('-', 56) + "|");
                        extractor.ExtractAndSortIndexes(inputText);
                        Console.WriteLine("|" + new string('-', 56) + "|");
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
                }
            }
            
        }
    }
}
