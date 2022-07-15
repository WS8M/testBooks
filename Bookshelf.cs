//Полка несет в себе информацию о хранимых в ней книгах
// обладает методами взаимодействия для взятия добавления и поиска книги
using System.Collections.Generic;

namespace Books
{
    internal class Bookshelf
    {
        private List<Book> _shelf; // список содержащихся книг на полке
        public List<Book> Shelf => _shelf;

        public Bookshelf(List<Book> shelf)
        {
            _shelf = shelf;
        }

        public List<string> GetInfo()
        {
            //Возвращает названия всех книг присутствующих на полке
            var info =  new List<string>();
            foreach (var book in _shelf)
            {
                info.Add(book.Title);
            }

            return info;
        }

        public Book TakeBook(string title)
        {
            //метод взятия книги с полки
            Book takeBook = null;
            foreach (var book in _shelf)
            {
                if (book.Title == title)
                {
                    takeBook = book;
                    _shelf.Remove(book);
                    break;
                }
            }
            return takeBook;
        }

        public void GetBook(Book book)
        {
            //метод добавления книги в полку.
            _shelf.Add(book);
        }
        //так же можно добавить метод проверки свободного места на полке
        // для чего необходимо будет добавить
        /*
            private float _width;
            + добавить инициализацию значения в конструктор.
         */
    }
}
