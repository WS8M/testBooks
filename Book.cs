// Базовый класс книги описывает ее внутреннее строение и передает информацию по запросу
using System.Collections.Generic;
using System.Text.RegularExpressions;

enum Language
{
    Rus,
    Eng
}
namespace Books
{
    internal class Book
    {
        private string _title = ""; 
        private List<string> _text;
        private Language _language;
        private int _numderOfPage;
        private int _price;
        private int _deterioration;
        private float _weight;
        private float _width;
        private float _height;

        public int openPage;

        public string Title => _title;
        public int Price => _price;
        public int Deterioration => _deterioration;
        public float Width => _width;
        public float Weight => _weight;
        public Book(string title, List<string> text, Language language, int price, int deterioration, float width, float height)
        {
            _title = title;
            _text = text;
            _language = language;
            _price = price;
            _deterioration = deterioration;
            _width = width;
            _height = height;
            _numderOfPage = CalculatingNumberOfPage();
            _width = CalculatingWidht(_numderOfPage);
        }

        public void OpenPage(int page)
        {
            //при поиске информации сохраняет информуцию на какой странице в данный момент открыта книга
            openPage= page;
        }

        public string GetInformation(string info)
        {
            // метод поиска страницы по заданному запросу.
            //возвращает странницу в которой содержится искомое значение
            foreach (var page in _text)
            {
                if(Regex.IsMatch(page, $"\\b({info}\\b"))
                {
                    OpenPage(_text.IndexOf(page));
                }
            }
            return _text[openPage];
        }

        private int CalculatingNumberOfPage()
        {
            //возвращает количество страниц в книге из расчета что 1 строка = 1 страница
            return  _text.Count;
        }
        
        private float CalculatingWidht(int number)
        {
            return (float)number * 0.001f; // 0.001f вес одной страницы для удобства можно вывести в константу.
                                           // или задавать для каждой книги в конструкторе
        }
    }
}
