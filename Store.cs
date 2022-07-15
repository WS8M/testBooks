using System;
using System.Collections.Generic;
using System.Linq;

namespace Books
{
    internal class Store
    {
        private  List<Bookshelf> _bookRow;
        private List<string> _catalog;
        internal List<Bookshelf> BookRow => _bookRow;

        public Store(List<Bookshelf> bookRow)
        {
            _bookRow = bookRow;
            _catalog = UpdateCatalog();
        }

        public List<Book> SeeShelf(int id)
        {
            return BookRow[id].Shelf;

        }

        public void GetCatalog()
        {
            if (_catalog.Count != 0)
            {
                foreach (var item in _catalog)
                {
                    Console.WriteLine(item);
                }
            }
            else UpdateCatalog();
        }
        
        private List<string> UpdateCatalog()
        {
            var catalog = new List<string>();
            foreach (var shelf in BookRow)
            {
                catalog.Concat(shelf.GetInfo());
            }
            return catalog;
        }

        public Book SellBook(string title, ref int wallet)
        {
            Book book = null;
            bool havebook = false;
            foreach (var shelf in BookRow)
            {
                var info = shelf.GetInfo();
                
                foreach (var t in info)
                {
                    if(t == title)
                    {
                        havebook = true;
                        break;
                    }
                }
                if (havebook)
                {
                    book = shelf.TakeBook(title);
                    if (wallet - book.Price < 0)
                    {
                        shelf.GetBook(book);
                        Console.WriteLine("Недостаточно средств");
                    }
                    else wallet -= book.Price;
                    UpdateCatalog();
                    break;
                }
                Console.WriteLine("Возможно книга на другой полке");
            }
            if (havebook)
            {
                Console.WriteLine("Хорошего дня, читайте с удовольствем");
            }
            else Console.WriteLine("Книга затерялась");
            return book;
        }

        public List<Book> SearchTreash()
        {
            List<Book> trashbooks = new List<Book>();
            foreach (var shelf in _bookRow)
            {
                foreach (var book in shelf.Shelf)
                {
                    if(book.Deterioration > 8)
                    {
                        trashbooks.Add(shelf.TakeBook(book.Title));
                    }
                } 
            }
            UpdateCatalog();
            return trashbooks;
        }
    }
}
