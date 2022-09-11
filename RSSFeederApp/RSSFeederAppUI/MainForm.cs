using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RSSFeederApp;

//TODO: Настройки для прокси-сервера - адрес и учётные данные для подключения
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
        private Config _config = Config.Load();

        /// <summary>
        /// Поле хранящее RSS ленту
        /// </summary>
        private List<RSSItem> _feeds = new List<RSSItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            feedsUMLTextBox.Text = _config.FeedsURL;
            reloadTimer.Start();
            reloadTimer.Interval = _config.ReloadTime * 60000;
        }

        /// <summary>
        /// Обработка запроса описания статьи
        /// </summary>
        private void feedsListBox_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_feeds[feedsListBox.SelectedIndex].Link);
        }

        /// <summary>
        /// Обработка запроса описания статьи
        /// </summary>
        private void feedsListBox_Click(object sender, EventArgs e)
        {
            pubDateLabel.Text = _feeds[feedsListBox.SelectedIndex].PubTime.ToString("dd.MM.yy HH:mm");
            titleTextBox.Text = _feeds[feedsListBox.SelectedIndex].Title;
            descriptionTextBox.Text = _feeds[feedsListBox.SelectedIndex].Description;
        }

        /// <summary>
        /// Обработка нажатия кнопки с частотой обновления ленты
        /// </summary>
        private void ReloadButtonClick(object sender, EventArgs e)
        {
            if (sender == oneMinuteReloadButton)
            {
                _config.ReloadTime = Config.ONE_MINUTE;
            }
            else if (sender == fiveMinuteReloadButton)
            {
                _config.ReloadTime = Config.FIVE_MINUTE;
            }
            else if (sender == fifteenMinuteReloadButton)
            {
                _config.ReloadTime = Config.FIFTEEN_MINUTE;
            }
            else if (sender == thirtyMinuteReloadButton)
            {
                _config.ReloadTime = Config.THIRTY_MINUTE;
            }
            else if (sender == oneHourReloadButton)
            {
                _config.ReloadTime = Config.ONE_HOURE;
            }

            _config.Save();
            reloadTimer.Interval = _config.ReloadTime * 60000;
        }

        /// <summary>
        /// Обработка нажатия кнопки с форматом текста
        /// </summary>
        private void TextFormatButtonClick(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Обработка ввода ссылки на ленту
        /// </summary>
        private void feedsUMLTextBox_TextChanged(object sender, EventArgs e)
        {
            _feeds.Clear();
            _config.FeedsURL = feedsUMLTextBox.Text;
            _config.Save();

            try
            {
                _feeds = RSSItem.ParsingRSSItems(_config.FeedsURL);
                feedsUMLTextBox.BackColor = Color.FloralWhite;
            }
            catch (Exception exception)
            {
                feedsUMLTextBox.BackColor = Color.LightSalmon;
            }

            InsertingItemsInTextBox();
        }

        /// <summary>
        /// Обновление ленты по отсчёту таймера
        /// </summary>
        private void reloadTimer_Tick(object sender, EventArgs e)
        {
            _feeds.Clear();
            _feeds = RSSItem.ParsingRSSItems(_config.FeedsURL);
            InsertingItemsInTextBox();
        }

        /// <summary>
        /// Метод заполняющий листбок элементами RSS ленты
        /// </summary>
        private void InsertingItemsInTextBox()
        {
            feedsListBox.Items.Clear();

            for (var i = 0; i < _feeds.Count; i++)
            {
                feedsListBox.Items.Insert(i,
                    "(" + _feeds[i].PubTime.ToString(
                        "dd.MM.yy HH:mm") + ") " 
                    + _feeds[i].Title);
            }
        }
    }
}
