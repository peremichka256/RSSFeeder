using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RSSFeederApp;

namespace RSSFeederAppUnitTests
{
    [TestFixture]
    internal class RSSItemTests
    {
        private List<RSSItem> testItems = RSSItem.ParsingRSSItems(Config.DefaultURL);

        [Test(Description = "Позитивный тест на текстовый формат")]
        public void TesDescription_TextFormat()
        {
            var text = "< pubDate > Wed, 14 Sep 2022 17:30:25 GMT </ pubDate >\n" +
                       "< dc:creator > megabax </ dc:creator >";
            var justText = text.Replace("<", "&lt;").Replace(">",
                "&gt;");
            testItems[0].IsTextHTML = false;
            testItems[0].Description = text;
            Assert.AreEqual(justText, testItems[0].Description,
                "Текст не был переформатирован в HTML");
        }

        [Test(Description = "Позитивный тест на формат описания в HTML")]
        public void TesDescription_HTMLFormat()
        {
            var text = "< pubDate > Wed, 14 Sep 2022 17:30:25 GMT </ pubDate >\n"+
                "< dc:creator > megabax </ dc:creator >";
            var htmlText = Regex.Replace(text, @"(<img src=[^>]+)>",
                "$1 width=\"300\"  >");
            testItems[0].IsTextHTML = true;
            testItems[0].Description = text;
            Assert.AreEqual(htmlText, testItems[0].Description,
                "Текст не был переформатирован в HTML");
        }

        [Test(Description = "Позитивный тест на присваивание значения")]
        public void TestIsHTML()
        {
            testItems[0].IsTextHTML = true;
            Assert.IsTrue(testItems[0].IsTextHTML,
                "Значение поля оказалось неправильным");
        }

        [Test(Description = "Позитивный тест на возврат присвоенного заголовка")]
        public void TestTitle_Get()
        {
            var defaultTitle = "Defaul title";
            testItems[0].Title = defaultTitle;
;           Assert.AreEqual(testItems[0].Title, defaultTitle,
            "Значение не было передано в поле");
        }

        [Test(Description = "Позитивный тест на возврат присвоенного времени")]
        public void TestPubTime_Get()
        {
            testItems[0].PubTime = DateTimeOffset.Now.ToLocalTime();
            Assert.AreEqual(testItems[0].PubTime, DateTimeOffset.Now.ToLocalTime(),
                "Значение не было передано в поле");
        }

        [Test(Description = "Позитивный тест на присвоение некорректной URL")]
        public void TestLink_SetWrong()
        {
            Assert.Throws<Exception>(() => { testItems[0].Link = "sdasas"; },
                "Метод должен был выбросить исключение на некорректную ссылку");
        }

        [Test(Description = "Позитивный тест на возврат заданной URL")]
        public void TestLink_Get()
        {
            testItems[0].Link = Config.DefaultURL;
            Assert.AreEqual(testItems[0].Link, Config.DefaultURL,
                "Значение не было занесено в поле");
        }

        [Test(Description = "Негативный тест на парсинг ленты при передачи null")]
        public void TestParsingRSSItems_NullURL()
        {
            Assert.Throws<ArgumentNullException>(() =>
                { List<RSSItem> testItems = RSSItem.ParsingRSSItems(null); },
                "Метод должен был выбросить исключение на пустую ссылку");
        }

        [Test(Description = "Позитивный тест на парсинг ленты с сайта")]
        public void TestPArsingRSSItems_WrongURL()
        {
            var testItems = RSSItem.
                ParsingRSSItems(Config.DefaultURL);
            Assert.NotNull(testItems, "При обработке стандартной ссылки" +
                                      " на ленту должно было вернуть список с элементами");
        }
    }
}
