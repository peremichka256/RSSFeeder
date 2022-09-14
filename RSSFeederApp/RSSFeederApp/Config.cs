using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

//TODO: Настройки для прокси-сервера - адрес и учётные данные для подключения
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
        public const string Path = "Config.xml";

        /// <summary>
        /// Ссылка на ленту
        /// </summary>
        private string _feedsURL;

        /// <summary>
        /// Частота обновления в минутах
        /// </summary>
        private int _reloadTime;

        /// <summary>
        /// Так и не понял как и зачем
        /// </summary>
        ///private WebProxy _proxy;
        /// 
        /// <summary>
        /// Константы содержащие минуты частоты обновления
        /// </summary>
        public const int ONE_MINUTE = 1;
        public const int FIVE_MINUTE = 5;
        public const int FIFTEEN_MINUTE = 15;
        public const int THIRTY_MINUTE = 30;
        public const int ONE_HOURE = 60;

        /// <summary>
        /// Свойство возвращающее и задающее ссылку на ленту
        /// </summary>
        public string FeedsURL
        {
            get => _feedsURL;
            set
            {
                Uri uriResult;
                bool isStringURL = Uri.TryCreate(value, UriKind.Absolute, out uriResult)
                              && (uriResult.Scheme == Uri.UriSchemeHttp 
                                  || uriResult.Scheme == Uri.UriSchemeHttps);
                if (isStringURL)
                {
                    _feedsURL = value;
                }
                else
                {
                    throw new Exception("URI is not correct");
                }
            }
        }

        /// <summary>
        /// Свойтсов возвращающее и хадающее частоту обновления ленты
        /// </summary>
        public int ReloadTime
        {
            get =>_reloadTime;
            set
            {
                if (value < ONE_MINUTE || value > ONE_HOURE)
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
        /// <returns>Загруженные или созданный заново конфиг</returns>
        public static Config Load(string path = Path)
        {
            var xml = new XmlSerializer(typeof(Config));

            try
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    Config userConfig = (Config)xml.Deserialize(fs);
                    return userConfig;
                }
            }
            catch
            {
                return new Config();
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
            ReloadTime = ONE_MINUTE;
        }
    }
}