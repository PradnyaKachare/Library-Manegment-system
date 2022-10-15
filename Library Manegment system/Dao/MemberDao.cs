using System;
using System.Collections.Generic;
using System.Text;
using Library_Manegment_system.Model;

namespace Library_Manegment_system.Dao
{
    interface MemberDao
    {
        bool AddMember(Member member);
        bool DeleteMember(int memberid);
        bool UpdateMember(int memberid, long mobile, string email);

        List<Member> getAllMembers();

        Member getMemberById(int memberid);
        Member ValidateUser(string email, string pass);
    }
}
