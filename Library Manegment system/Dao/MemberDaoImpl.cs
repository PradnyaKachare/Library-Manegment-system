using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Library_Manegment_system.Configuration;
using Library_Manegment_system.Model;
using System.Reflection.PortableExecutable;
using System.Net;
using System.Security.Cryptography;
using System.Globalization;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace Library_Manegment_system.Dao
{
   class MemberDaoImpl : MemberDao
    {    
        static void Main(string[] args)
        {
            MemberDaoImpl m = new MemberDaoImpl();
            string retry = "No";

            do
            {
                int ch;
                Console.WriteLine("Enter \n 1: Add Member \n 2: Get Member \n 3: Delete Member \n 4: Update Member");
                 ch = int.Parse(Console.ReadLine());
             
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter Member id ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Member Name ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Member Address ");
                        string adr = Console.ReadLine();

                        Console.WriteLine("Enter Member Mobile number ");
                        long mob = long.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Member EmailId ");
                        string eml = Console.ReadLine();

                        Console.WriteLine("Enter Member Passaword ");
                        string psw = Console.ReadLine();

                        Console.WriteLine("Enter Member Role");
                        string rol = Console.ReadLine();


                        Member member = new Member(id,name, adr, mob, eml, psw, rol);

                        if (m.AddMember(member))
                        {
                            Console.WriteLine("Member Added Scuussfully!!!");
                        }
                        else
                        {
                            Console.WriteLine("Something went wromg..");
                        }
                        break;

                    case 2:
                         Console.WriteLine("List of Member");
                        List<Member> memlist = m.getAllMembers();

                        foreach (Member mem in memlist)
                        {                           
                            Console.WriteLine(mem.Memberid);
                           //Console.WriteLine(mem.id + "  " + mem.name + " " + mem.adr + " " + mem.mob + " " + mem.eml + " " + mem.psw + " " + mem.rol);
                           Console.WriteLine(mem.Memberid + "  " + mem.membername + " " + mem.addr + " " + mem.mobile + " " + mem.email + " " + mem.password + " " + mem.role);
                        }                        
                        break;

                    case 3:
                        Console.WriteLine("Enter Member id u want to delete");
                        int Memberid = Convert.ToInt32(Console.ReadLine());
                        m.DeleteMember(Memberid);

                        if (m.DeleteMember(Memberid))
                        {
                            Console.WriteLine("Member Deleted Scuussfully!!!");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong..");
                        }
                        break;
                  
                    case 4:                     
                        Console.WriteLine("Enter Member id you want update");
                        int memberid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Member Name you want update");
                        string membername = Console.ReadLine();
                        Console.WriteLine("Enter Member Address you want update");
                        string addr = Console.ReadLine();
                        Console.WriteLine("Enter Member Mobile number you want update");
                        long mobile = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Member EmailId you want update");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter Member Passaword you want update");
                        string password = Console.ReadLine();
                        Console.WriteLine("Enter Member Role you want update");
                        string role = Console.ReadLine();

                     //   m.UpdateMember(memberid, membername, addr, mobile, email, password, role);

                        if (m.UpdateMember(memberid, membername, addr, mobile, email, password, role))
                        {
                            Console.WriteLine("Member Updated Scuussfully!!!");
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

        public bool AddMember(Member mbr)
        {
            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("insert into Member values(@id,@name,@adr,@mob,@eml,@psw,@rol)", con);

                    /* cmd.Parameters.AddWithValue("@id", mbr.memberid);
                     cmd.Parameters.AddWithValue("@name", mbr.membername);
                     cmd.Parameters.AddWithValue("@adr", mbr.addr);
                     cmd.Parameters.AddWithValue("@mobile", mbr.mobile);
                     cmd.Parameters.AddWithValue("@email", mbr.email);
                     cmd.Parameters.AddWithValue("@psw", mbr.password);
                     cmd.Parameters.AddWithValue("@rol", mbr.role);*/

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


        public List<Member> getAllMembers()
        {
            List<Member> list = new List<Member>();

            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("select * from Member", con);

                    SqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int memberid = (int)r[0];
                        string membername = (string)r[1];
                        string addr = (string)r[2];
                        long mobile = (long)r[3];
                        string email = (string)r[4];
                        string password = (string)r[5];
                        string role = (string)r[6];
                        Member m = new Member(memberid, membername, addr, mobile, email, password, role);

                        list.Add(m);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

       
      
        public bool DeleteMember(int memberid)
        {
            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("delete from Member where memberid=@id", con);

                    cmd.Parameters.AddWithValue("@id", memberid);

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


        public bool UpdateMember(int memberid, string membername, string addr, long mobile, string email, string password, string role)
        {
            try
            {
                using (SqlConnection con = DBConnect.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("update book where memberid=@memberid set BookName=@BookName ", con);
                  
                    cmd.Parameters.AddWithValue("@memberid", memberid);
                    cmd.Parameters.AddWithValue("@membername", membername);
                    cmd.Parameters.AddWithValue("@addr", addr);
                    cmd.Parameters.AddWithValue("@mobile", mobile);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);

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

       

        bool MemberDao.AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        bool MemberDao.DeleteMember(int memberid)
        {
            throw new NotImplementedException();
        }

        bool MemberDao.UpdateMember(int memberid, long mobile, string email)
        {
            throw new NotImplementedException();
        }

        List<Member> MemberDao.getAllMembers()
        {
            throw new NotImplementedException();
        }

        Member MemberDao.getMemberById(int memberid)
        {
            throw new NotImplementedException();
        }

        Member MemberDao.ValidateUser(string email, string pass)
        {
            throw new NotImplementedException();
        }
    }
}



