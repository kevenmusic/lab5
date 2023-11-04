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
                        resultBuilder.AppendLine($"| Индекс {index,-11}| соответствует стране {countries[i],-13} |");
                        indexFound = true;
                        break;
                    }
                }

                if (!indexFound)
                {
                    resultBuilder.AppendLine($"| Для индекса {index,-6}| не найдена соответствующая страна.{"",0} |");
                }
            }

            Console.WriteLine(resultBuilder.ToString());
        }
    }
}
