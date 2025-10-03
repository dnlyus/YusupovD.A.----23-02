using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Book
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }

        public Book(string title, int pageCount, decimal price)
        {
            Title = title;
            PageCount = pageCount;
            Price = price;
        }

        public void IncreasePages()
        {
            PageCount += 10;
        }

        public void ReducePriceIfManyPages()
        {
            if (PageCount > 100)
            {
                Price /= 2;
            }
        }

        public override string ToString()
        {
            return $"Название: {Title}\nКоличество страниц: {PageCount}\nЦена: {Price:F2} руб.";
        }
    }
}