using System.Collections.Generic;

namespace Books
{
    internal static class Disposal
    {
        private static float _pricePerKg;
        public static void  PickUpBooks(List<Book> books, ref int wallet)
        {
            //метод получает книги и высчитывает возвращаемую стоимость
            var price = 0;
            foreach (var book in books)
            {
                price += (int) (book.Weight * _pricePerKg);
            }
            wallet += price;
        }
    }
}
