using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Library_Manegment_system.Configuration;
using Library_Manegment_system.Model;

namespace Library_Manegment_system.Dao
{
    class BookDaoImpl : BookDao
    {
        public List<Book> getAllBooks()
        {
            List<Book> booklist = new List<Book>();

            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("select * from book", con);
                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int bid = (int)r[0];
                        string bnm = (string)r[1];
                        string anm = (string)r[2];
                        int price = (int)r[3];
                        int copies = (int)r[4];
                        Book bk = new Book(bid, bnm, anm, price, copies);
                        booklist.Add(bk);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return booklist;
        }

        public bool AddBook(Book bk)
        {
            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("insert into book values(@i,@bknm,@anm,@price,@no)", con);
                    cmd.Parameters.AddWithValue("@i", bk.Bookid);
                    cmd.Parameters.AddWithValue("@bknm", bk.BookName);
                    cmd.Parameters.AddWithValue("@anm", bk.AuthorName);
                    cmd.Parameters.AddWithValue("@price", bk.Price);
                    cmd.Parameters.AddWithValue("@no", bk.NoOfCopies);
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }    
       
        public Book getBookById(int id)
        {
            throw new NotImplementedException();
        }


        public bool DeleteBook(Book bk)
        {
            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("delete  book where Bookid=bk", con);
                    cmd.Parameters.AddWithValue("@i", bk.Bookid);
                    
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        
        public bool DeleteBook(int bookid)
        {
            throw new NotImplementedException();
        }



        public bool UpdateBook(Book bk ,int id, string bknm, string anm)
        {
            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("update  book where Bookid=bk", con);
                    cmd.Parameters.AddWithValue("@i", bk.Bookid);

                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public bool UpdateBook(int id, string bknm, string anm)
        {
            throw new NotImplementedException();
        }
        
        
    }
}
