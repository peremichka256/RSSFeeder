using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using RSSFeederApp;

namespace RSSFeederAppUI
{
    /// <summary>
    /// Класс главного окна приложения
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Поле хранящее настройки
        /// </summary>
        private Config _config = new Config();

        /// <summary>
        /// Поле хранящее RSS ленту
        /// </summary>
        private List<RSSItem> feeds = new List<RSSItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            feedsUMLTextBox.Text = _config.FeedsURL;
            try
            {
                Config.Load();
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Файл конфигурации не соответствует формату. Использована стандартная конфигурация.",
                    "Ошибка файла конфигуарции");
                _config = new Config();
            }
        }

        /// <summary>
        /// Загружает из ссылки ленту в список
        /// </summary>
        public List<RSSItem> LoadRSS(string url)
        {
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            var itemsDTO = new List<RSSItem>();

            try
            {
                using (var reader = XmlReader.Create(url, settings))
                {
                    var feed = SyndicationFeed.Load(reader);
                    itemsDTO.AddRange(RSSItem.GetItems(feed));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"При чтении ленты {url} произошла ошибка:" +
                                $" {e.Message}", "Ошибка");
            }

            return itemsDTO;
        }

        /// <summary>
        /// Прогружает список статей по введенной в строку ссылке
        /// </summary>
        private void feedsUMLTextBox_TextChanged(object sender, EventArgs e)
        {
            _config.FeedsURL = feedsUMLTextBox.Text;
            _config.Save();
            var listFeeds = LoadRSS(_config.FeedsURL);

            for (var i = 0; i < listFeeds.Count; i++)
            {
                feeds.Insert(i, listFeeds[i]);
                feedsListBox.Items.Insert(i, "("
                                             + feeds[i].PubTime.ToString("dd.MM.yy HH:mm")
                                             + ") " + feeds[i].Title);
            }
        }

        /// <summary>
        /// Обработка запроса описания статьи
        /// </summary>
        private void feedsListBox_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(feeds[feedsListBox.SelectedIndex].Link);
        }

        /// <summary>
        /// Обработка запроса описания статьи
        /// </summary>
        private void feedsListBox_Click(object sender, EventArgs e)
        {
            pubDateLabel.Text = feeds[feedsListBox.SelectedIndex].PubTime.ToString("dd.MM.yy HH:mm");
            titleTextBox.Text = feeds[feedsListBox.SelectedIndex].Title;
            descriptionTextBox.Text = feeds[feedsListBox.SelectedIndex].Description;
        }

        /// <summary>
        /// Обработка нажатия кнопки с частотой обновления ленты
        /// </summary>
        private void ReloadButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обработка нажатия кнопки с форматом текста
        /// </summary>
        private void TextFormatButtonClick(object sender, EventArgs e)
        {

        }
    }
}
