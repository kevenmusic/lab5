using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary5
{
    public class AddressExtractor
    {
        public string[] indexes;
        public string[] countries;

        public AddressExtractor(string[] indexes, string[] countries)
        {
            this.indexes = indexes;
            this.countries = countries;
        }

        public void ExtractAndSortIndexes(string inputText)
        {
            Regex regex = new Regex(@"\b\d{5}\b|[A-Za-z]\d[A-Za-z]|\b\d{6}\b|[A-Za-z][A-Za-z]\s\d\d");
            MatchCollection matches = regex.Matches(inputText);

            StringBuilder resultBuilder = new StringBuilder();

            foreach (Match match in matches)
            {
                string index = match.Value;

                bool indexFound = false;
                for (int i = 0; i < indexes.Length; i++)
                {
                    if (indexes[i] == index)
                    {
                        resultBuilder.AppendLine($"| Индекс {index,-11}| Соответствует страна {countries[i],-13} |");
                        indexFound = true;
                        break;
                    }
                }

                if (!indexFound)
                {
                    resultBuilder.AppendLine($"| Индекс {index,-11}| Не найдена соответствующая страна.{"",0} |");
                }
            }

            string resultString = resultBuilder.ToString().Trim();
            Console.WriteLine(resultString);
        }
    }
}
