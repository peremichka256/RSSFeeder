using System.ServiceModel.Syndication;
using System.Xml;

namespace RSSFeederApp
{
    /// <summary>
    /// Класс описывающий элемент RSS ленты
    /// </summary>
    public class RSSItem
    {
        /// <summary>
        /// Название
        /// </summary>
        private string _title;

        /// <summary>
        /// Дата публикации
        /// </summary>
        private DateTimeOffset _pubTime;

        /// <summary>
        /// Описание статьи
        /// </summary>
        private string _description;

        /// <summary>
        /// Ссылка на статью
        /// </summary>
        private string _link;

        /// <summary>
        /// Свойство задания и возврата названия
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Свойство задания и возврата даты публикации
        /// </summary>
        public DateTimeOffset PubTime
        {
            get { return _pubTime.ToLocalTime(); }
            set { _pubTime = value; }
        }

        /// <summary>
        /// Свойство задания и возврата описание статьи
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Свойство задания и возврата ссылки на статью
        /// </summary>
        public string Link
        {
            get { return _link; }
            set
            {
                Uri uriResult;
                bool result = Uri.TryCreate(value, UriKind.Absolute, out uriResult)
                              && (uriResult.Scheme == Uri.UriSchemeHttp 
                                  || uriResult.Scheme == Uri.UriSchemeHttps);
                if (result)
                {
                    _link = value;
                }
                else
                {
                    throw new Exception("URI is not valid");
                }
            }
        }

        /// <summary>
        /// Конструтор передающий основную информации в поля класса
        /// </summary>
        /// <param name="item">Объект класса сериализации</param>
        public RSSItem(SyndicationItem item)
        {
            Title = item.Title.Text;
            Description = item.Summary.Text;
            PubTime = item.PublishDate;
            Link = item.Links.First().Uri.ToString();
        }

        /// <summary>
        /// Конвертирует всю ленту в массив DTO
        /// </summary>
        /// <param name="feed">Лента</param>
        /// <returns></returns>
        public static RSSItem[] GetItems(SyndicationFeed feed)
        {
            var ret = new RSSItem[feed.Items.Count()];

            var i = 0;
            foreach (var syndicationItem in feed.Items)
            {
                ret[i] = new RSSItem(syndicationItem);
                i++;
            }

            return ret;
        }

        /// <summary>
        /// Парсит RSS ленту в список объектов Item
        /// </summary>
        /// <param name="url">Ссылка на ленту</param>
        /// <returns></returns>
        public static List<RSSItem> ParsingRSSItems(string url)
        {
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            var items = new List<RSSItem>();
            
            using (var reader = XmlReader.Create(url, settings))
            {
                var feed = SyndicationFeed.Load(reader);
                items.AddRange(GetItems(feed));
            }

            return items;
        }
    }
}
