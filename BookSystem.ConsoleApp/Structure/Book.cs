using System;
using System.Collections.Generic;
using System.Text;

namespace BookSystem.ConsoleApp.Structure
{
    class Book
    {
        static int NumberCount = 0;

        public Book()
        {
            NumberCount++;
            this.NumberOnShelf = NumberCount;
        }

        public Book(string BookName, string BookAuthor, int BookPage, int BookPrice, int BookBarcode)
            : this()
        {
            this.Name = BookName;
            this.Author = BookAuthor;
            this.PageCount = BookPage;
            this.Price = BookPrice;
            this.Barcode = BookBarcode;
        }

        public string Name { get; set; }
        public string Author { get; set; }
        public int NumberOnShelf { get; private set; }
        public int Barcode { get; set; }
        public int PageCount { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{NumberOnShelf}. {Name} by {Author} \n" +
                $"{PageCount} Pages \n" +
                $"Price: {Price}$ \n" +
                $"Scan Barcode: {Barcode}";
        }
    }
}
