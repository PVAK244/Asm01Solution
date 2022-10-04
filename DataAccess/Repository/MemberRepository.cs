using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<MemberObject> GetMembers() 
            => MemberManagement.Instance.GetMemberList();
        public MemberObject GetMemberByID(int memberId) 
            => MemberManagement.Instance.GetMemberByID(memberId);
        public MemberObject LogIn(string email, string password)
            => MemberManagement.Instance.LogIn(email, password);
        public void InsertMember(MemberObject member) 
            => MemberManagement.Instance.AddNew(member);
        public void DeleteMember(MemberObject member) 
            => MemberManagement.Instance.Remove(member);
        public void UpdateMember(MemberObject member) 
            => MemberManagement.Instance.Update(member);
    }
}
