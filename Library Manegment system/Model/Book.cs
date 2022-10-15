using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Manegment_system.Model
{
    class Book
    {
        int bookid;
        string bookName;
        string authorName;
        int noOfCopies;
        int price;

        public Book(int bookid, string bookName, string authorName, int noOfCopies, int price)
        {
            this.Bookid = bookid;
            this.BookName = bookName;
            this.AuthorName = authorName;
            this.NoOfCopies = noOfCopies;
            this.Price = price;
        }

        public int Bookid { get => bookid; set => bookid = value; }
        public string BookName { get => bookName; set => bookName = value; }
        public string AuthorName { get => authorName; set => authorName = value; }
        public int NoOfCopies { get => noOfCopies; set => noOfCopies = value; }
        public int Price { get => price; set => price = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
