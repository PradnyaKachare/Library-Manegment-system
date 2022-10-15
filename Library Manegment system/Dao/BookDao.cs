using System;
using System.Collections.Generic;
using System.Text;
using Library_Manegment_system.Model;

namespace Library_Manegment_system.Dao
{
    interface BookDao
    {
        //Book Get(int id);
        //Book GetById(int id);        
        List<Book> getAllBooks();
        bool AddBook(Book b);
        bool DeleteBook(int bookid);
        bool UpdateBook(int id, string bknm, string anm);
        Book getBookById(int id);
      //  Book getBookByName(string bknm);
                

    }

}
