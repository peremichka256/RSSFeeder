using System.Xml.Serialization;

namespace RSSFeederApp
{
    /// <summary>
    /// Класс файла настройки
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Стандартный путь конфигурации
        /// </summary>
        private const string Path = "Config.xml";

        /// <summary>
        /// Ссылка на ленту
        /// </summary>
        private string _feedsURL;

        /// <summary>
        /// Частота обновления в минутах
        /// </summary>
        private int _reloadTime;

        /// <summary>
        /// Свойство возвращающее и задающее ссылку на ленту
        /// </summary>
        public string FeedsURL
        {
            get { return _feedsURL; }
            set { _feedsURL = value; }
        }

        /// <summary>
        /// Свойтсов возвращающее и хадающее частоту обновления ленты
        /// </summary>
        public int ReloadTime
        {
            get { return _reloadTime; }
            set
            {
                if (value < 0 || value > 60)
                {
                    throw new Exception("Reload time should be in 1 hour range");
                }

                _reloadTime = value;
            }
        }

        /// <summary>
        /// Загрузка конфига
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static Config Load(string path = Path)
        {
            var xml = new XmlSerializer(typeof(Config));
        
            using (var fs = new FileStream(path, FileMode.Open))
            {
                try
                {
                    Config ret = (Config)xml.Deserialize(fs);
                    return ret;
                }
                catch
                {
                    throw new InvalidCastException("Invalid config data");
                }
            }
        }

        /// <summary>
        /// Сохранение пользовательского конфига в xml-файл
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path = Path)
        {
            var xml = new XmlSerializer(typeof(Config));

            using (var fs = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(fs, this);
            }
        }

        /// <summary>
        /// Конструтор с дефолтными настройками конфига
        /// </summary>
        public Config()
        {
            FeedsURL = "https://habr.com/rss/interesting";
            ReloadTime = 2;
        }
    }
}