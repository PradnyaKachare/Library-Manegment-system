using System;
using System.Collections.Generic;
using System.Text;
using Library_Manegment_system.Model;

namespace Library_Manegment_system.Dao
{
    interface BookDao
    {       
        List<Book> getAllBooks();
        bool AddBook(Book b);
        bool DeleteBook(int bookid);
        bool UpdateBook(int id, string bknm, string anm,int cpy,int price);
        Book getBookById(int id);   
    }
}
