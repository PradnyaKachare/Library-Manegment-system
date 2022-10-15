using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Manegment_system.Model
{
    class Member
    {
        int memberid;
        string membername;
        string addr;
        long mobile;
        string email;
        string password;
        string role;

        public Member(int memberid, string membername, string addr, long mobile, string email, string password, string role)
        {
            this.Memberid = memberid;
            this.Membername = membername;
            this.Addr = addr;
            this.Mobile = mobile;
            this.Email = email;
            this.Password = password;
            this.Role = role;
        }

        public int Memberid { get => memberid; set => memberid = value; }
        public string Membername { get => membername; set => membername = value; }
        public string Addr { get => addr; set => addr = value; }
        public long Mobile { get => mobile; set => mobile = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
