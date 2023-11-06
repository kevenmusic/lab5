using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ClassLibrary5;

namespace UnitTestProject5
{
    [TestClass]
    public class AddressExtractorTests
    {
        [TestMethod]
        public void ExtractAndSortIndexes_ShouldReturnCorrectOutput()
        {
            // Arrange
            string[] indexes = new string[] {
                "12345",
                "10007",
                "98765"
            };
            string[] countries = new string[] {
                "Россия",
                "США",
                "Россия"
            };
            string inputText = "Адреса: 12345 Россия; 10007 США; 98765 Россия;";

            AddressExtractor extractor = new AddressExtractor(indexes, countries);

            // Act
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            extractor.ExtractAndSortIndexes(inputText);
            string expectedOutput = "| Индекс 12345      | Соответствует страна Россия        |\r\n" +
                                    "| Индекс 10007      | Соответствует страна США           |\r\n" +
                                    "| Индекс 98765      | Соответствует страна Россия        |\r\n";

            // Assert
            Assert.AreEqual(expectedOutput, sw.ToString());
        }

        [TestMethod]
        public void ExtractAndSortIndexes_ShouldHandleInvalidIndexes()
        {
            // Arrange
            string[] indexes = new string[] {
                "12345",
                "10007",
                "98765"
            };
            string[] countries = new string[] {
                "Россия",
                "США",
                "Россия"
            };
            string inputText = "Адреса: 12345 Россия; 10077 США; 98765 Россия;";

            AddressExtractor extractor = new AddressExtractor(indexes, countries);

            // Act
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            extractor.ExtractAndSortIndexes(inputText);
            string expectedOutput = "| Индекс 12345      | Соответствует страна Россия        |\r\n" +
                                    "| Индекс 10077      | Не найдена соответствующая страна. |\r\n" +
                                    "| Индекс 98765      | Соответствует страна Россия        |\r\n";

            // Assert
            Assert.AreEqual(expectedOutput, sw.ToString());
        }

        [TestMethod]
        public void ExtractAndSortIndexes_ShouldHandleInvalidIndexes_second()
        {
            // Arrange
            string[] indexes = new string[] {
                "HM 05",
                "10207",
                "241425"
            };
            string[] countries = new string[] {
                "Россия",
                "США",
                "Россия"
            };
            string inputText = "Адреса: HM 04 Россия; 10037 США; 98765 Россия;";

            AddressExtractor extractor = new AddressExtractor(indexes, countries);

            // Act
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            extractor.ExtractAndSortIndexes(inputText);
            string expectedOutput = "| Индекс HM 04      | Не найдена соответствующая страна. |\r\n" +
                                    "| Индекс 10037      | Не найдена соответствующая страна. |\r\n" +
                                    "| Индекс 98765      | Не найдена соответствующая страна. |\r\n";

            // Assert
            Assert.AreEqual(expectedOutput, sw.ToString());
        }
    }
}
