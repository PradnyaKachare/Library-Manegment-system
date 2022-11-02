using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Library_Manegment_system.Configuration;
using Library_Manegment_system.Model;
using System.Reflection.PortableExecutable;
using System.Net;
using System.Security.Cryptography;

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
                ch = int.Parse(Console.ReadLine());
               
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
                         Console.WriteLine("List of Books");
                        List<Book> bkList = b.getAllBooks();
                        
                        foreach (Book list in bkList)
                        {
                            Console.WriteLine(list.Bookid+" "+list.BookName+ " "+list.AuthorName+ " "+list.NoOfCopies+" "+list.Price);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter book id u want to delete");
                        int bookid = Convert.ToInt32(Console.ReadLine());
                        b.DeleteBook(bookid);

                        if (b.DeleteBook(bookid))
                        {
                            Console.WriteLine("Book Deleted Scuussfully!!!");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong..");
                        }
                        break;


                    case 4:
                        Console.WriteLine("Enter book id you want update");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter book Name you want update");
                        string bknm = Console.ReadLine();
                        Console.WriteLine("Enter Author nameyou want update");
                        string anm = Console.ReadLine();
                        Console.WriteLine("Enter Number Of Copies you want update");
                        int cpy = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Price you want update");                         
                        int price= Convert.ToInt32(Console.ReadLine());
                     
                        if (b.UpdateBook(id, bknm, anm,cpy,price))
                        {
                            Console.WriteLine("Book Updated Scuussfully!!!");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong..");
                        }
                        break;

                    default:
                        Console.WriteLine("Would you like to retry?");
                        retry = Console.ReadLine();
                        break;                   
                        
                }
            }
            while (retry != "No");
           
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
                       // Console.WriteLine(r);
                        int bid = (int)r[0];
                        string bnm = (string)r[1];
                        string anm = (string)r[2];
                        int price = (int)r[3];
                        int copies = (int)r[4];
                       
                        
                        Book bk = new Book(bid, bnm, anm, price, copies);
                       // Console.WriteLine(bk.Bookid);
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


        public bool DeleteBook(int bookid)
        {
            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("delete from book where Bookid=@i", con);
                  
                    cmd.Parameters.AddWithValue("@i", bookid);
                    
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

      

        public bool UpdateBook(int id, string bknm, string anm,int cpy,int price)            
        {
            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Book \r\nSET BookName = @bknm, Authorname = @anm,noOfCopies=@cpy,price=@price Where bookid = @id  ", con);
                  
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@bknm", bknm);
                    cmd.Parameters.AddWithValue("@anm", anm);
                    cmd.Parameters.AddWithValue("@cpy", cpy);
                    cmd.Parameters.AddWithValue("@price", price);

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
        

    }
}
