using System;
using System.IO;
using NUnit.Framework;
using RSSFeederApp;

namespace RSSFeederAppUnitTests
{
    [TestFixture]
    public class ConfigTests
    {
        [Test(Description = "���������� ���� �� ����������" +
                            " ���������������� ��������")]
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
                "���� �������� �� ��� �������");
        }

        [Test(Description = "")]
        public void TestLoad()
        {
            if (File.Exists(Config.Path))
            {
                File.Delete(Config.Path);
            }

            var testConfig = Config.Load();

            Assert.NotNull(testConfig, "����� ��������" +
                                       " ���� �� ��� ������������");
        }

        [Test(Description = "���������� ���� �� ������� ������� ����������")]
        public void TestReloadTime()
        {
            var testConfig = new Config();
            var wrongReloadTime = 100;

            Assert.Throws<Exception>(() =>
                { testConfig.ReloadTime = wrongReloadTime; },
                "��� ������� ����� ������������� " +
                "�������� ���������� �� ��������");
        }

        [Test(Description = "���������� ���� �� �������� ������ �� RSS �����")]
        public void TestFeedsURL()
        {
            var testConfig = new Config();
            var wrongURL = "sdasfadfsd";

            Assert.Throws<Exception>(() =>
                { testConfig.FeedsURL = wrongURL; },
                "��� ������� ����� ������������� " +
                "�������� ���������� �� ��������");
        }
    }
}