using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Library_Manegment_system.Configuration;
using Library_Manegment_system.Model;
using System.Reflection.PortableExecutable;
using System.Net;

namespace Library_Manegment_system.Dao
{
    class BookDaoImpl : BookDao
    {
        static void Main(string[] args)
        {
            BookDaoImpl b = new BookDaoImpl();
            string retry = "No";

            do
            {
                int ch;
                Console.WriteLine("Enter \n 1: Add Book \n 2: Get Books \n 3: Delete Book \n 4: Update Book");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter Book id:");
                        int bkId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Book Name:");
                        string bkName = Console.ReadLine();

                        Console.WriteLine("Enter Book Author Name:");
                        string bkAuthName = Console.ReadLine();

                        Console.WriteLine("Enter No of Copies:");
                        int bkCopies = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Price:");
                        int bkPrice = Convert.ToInt32(Console.ReadLine());

                        Book book = new Book(bkId, bkName, bkAuthName, bkCopies, bkPrice);

                        if (b.AddBook(book))
                        {
                            Console.WriteLine("Book Added Scuussfully!!!");
                        }
                        else
                        {
                            Console.WriteLine("Something went wromg..");
                        }
                        break;

                    case 2:
                        //Console.WriteLine("List of Book:");
                        List<Book> bkList = b.getAllBooks();
                        foreach (Book c in bkList)
                        {
                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter book id u want to delete");
                        int bookid = Convert.ToInt32(Console.ReadLine());
                        b.DeleteBook(bookid);  
                        break;

                    case 4:
                        Console.WriteLine("Enter book id you want update");
                        int Bookid = Convert.ToInt32(Console.ReadLine());
                      //  b.UpdateBook(Bookid, int id,bknm,anm);

                        break;

                    default:
                        Console.WriteLine("Would you like to retry?");
                        retry = Console.ReadLine();
                        break;
                }
            } while (retry != "No");


        }

       

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
                    SqlCommand cmd = new SqlCommand("insert into book values(@bknm,@anm,@price,@no)", con);
                   // cmd.Parameters.AddWithValue("@id", bk.Bookid);
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
                    SqlCommand cmd = new SqlCommand("delete from book where Bookid=@i", con);
                  
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
                    SqlCommand cmd = new SqlCommand("update  book where Bookid=@i", con);
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
