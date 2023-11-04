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

            string inputText = @"
          |--------------------------------------------------------------------------------------------------------------------------------------------------------|
          | Адреса: 12345 Россия, Москва, ул. Примерная, д.1; 10007 США, Нью-Йорк, ул. Тестовая, д.2; 98765 Россия, Санкт-Петербург, ул. Тестовая, д.3             |
          | 01090 Франция, Париж, ул. Тестовая, д.4; M4E Канада, Торонто, ул. Примерная, д.5; 23552 Франция, Ницца, ул. Примерная, д.6                             |
          | 01094 Франция, Париж, ул. Тестовая, д.4; 35E Канада, Торонто, ул. Примерная, д.5; 235522 Франция, Ницца, ул. Примерная, д.6                            |
          | 01127 Германия, Берлин, ул. Тестовая, д.7; 84135 Италия, Рим, ул. Примерная, д.8; 28300 Испания, Мадрид, ул. Тестовая, д.9                             |
          | 246020 Беларусь, Гомель, пр. Речецкий, д.135; 84635 Италия, Рим, ул. Примерная, д.8; 344453 Испания, Мадрид, ул. Тестовая, д.9;HM 01 Бермуды, Гамильтон|
          |--------------------------------------------------------------------------------------------------------------------------------------------------------|";

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
