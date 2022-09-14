using System;
using System.IO;
using NUnit.Framework;
using RSSFeederApp;

namespace RSSFeederAppUnitTests
{
    [TestFixture]
    public class ConfigTests
    {
        [Test(Description = "Позитивный тест на сохранение" +
                            " пользовательских настроек")]
        public void TestSave()
        {
            if (File.Exists(Config.Path))
            {
                File.Delete(Config.Path);
            }

            var testConfig = Config.Load();
            var newReloadTimeValue = 47;
            testConfig.ReloadTime = newReloadTimeValue;
            testConfig.Save();
            var userConfig = Config.Load();

            Assert.AreEqual(newReloadTimeValue, userConfig.ReloadTime,
                "Файл настроек не был получен");
        }

        [Test(Description = "")]
        public void TestLoad()
        {
            if (File.Exists(Config.Path))
            {
                File.Delete(Config.Path);
            }

            var testConfig = Config.Load();

            Assert.NotNull(testConfig, "После удаления" +
                                       " файл не был восстановлен");
        }

        [Test(Description = "Негативный тест на свойсто времени обновления")]
        public void TestReloadTime()
        {
            var testConfig = new Config();
            var wrongReloadTime = 100;

            Assert.Throws<Exception>(() =>
                { testConfig.ReloadTime = wrongReloadTime; },
                "При попытке ввода некорректного " +
                "значения исключение не появлось");
        }

        [Test(Description = "Негативный тест на свойство ссылки на RSS ленту")]
        public void TestFeedsURL()
        {
            var testConfig = new Config();
            var wrongURL = "sdasfadfsd";

            Assert.Throws<Exception>(() =>
                { testConfig.FeedsURL = wrongURL; },
                "При попытке ввода некорректного " +
                "значения исключение не появлось");
        }
    }
}