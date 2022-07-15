//Входной файл программы содержит вызовы методов с 1 по 4 и реализацию метода подпереть стол книгой.
using System;
using System.Collections.Generic;
namespace Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wallet = 100;
            var store = new Store(new List<Bookshelf>());
            store.GetCatalog(); // 1 посмотреть каталог книг
            var book = store.SellBook("Название книги", ref wallet);// 2 продать
            book.GetInformation("строка для поиска"); // 3 найти информацию в книге
            FixTheTableWithBook(12.0f, store.SeeShelf(1)); // 4 подпереть стол
            Disposal.PickUpBooks(store.SearchTreash(),ref wallet); // 5 утилизировать книги
        }

        private static void FixTheTableWithBook(float height, List<Book> books)
        {
            //идет обычный подбор книги по размеры через перебор всех книг взятых с 1 полки
            //возможно расширение и усложнение метода для получения заданного размера путем взятия нескольких книг.
            //тогда необходимо будет добавить метод сортировки и перебора.
            bool fix = false;
            foreach (var book in books)
            {
                if (height == book.Width)
                {
                    fix = true;
                }
            }
            if (!fix)
            {
                Console.WriteLine("не найдена подходящая книга");
            }
        }
    }
}