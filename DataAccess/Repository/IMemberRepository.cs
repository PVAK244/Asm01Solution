using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemberByID(int memberId);
        MemberObject LogIn(string email, string password);
        void InsertMember(MemberObject member);
        void DeleteMember(MemberObject member);
        void UpdateMember(MemberObject member);
    }
}
