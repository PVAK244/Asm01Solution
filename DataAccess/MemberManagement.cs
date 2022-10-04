using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace DataAccess
{
    public class MemberManagement
    {
        private static MemberManagement instance = null;
        private static readonly object instanceLock = new object();

        private MemberManagement() { }
        public static MemberManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<MemberObject> GetMemberList()
        {
            List<MemberObject> members;
            try
            {
                var fStoreDB = new FStoreContext();
                members = fStoreDB.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public MemberObject GetMemberByID(int memberId)
        {
            MemberObject member = null;
            try
            {
                var fStoreDB = new FStoreContext();
                member = fStoreDB.Members.SingleOrDefault(member => member.MemberId == memberId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddNew(MemberObject member)
        {
            try
            {
                MemberObject _member = GetMemberByID(member.MemberId);
                if (_member == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Members.Add(member);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public void Update(MemberObject member)
        {
            try
            {
                MemberObject m = GetMemberByID(member.MemberId);
                if (m != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<MemberObject>(member).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(MemberObject member)
        {
            try
            {
                MemberObject _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Members.Remove(member);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MemberObject LogIn(string email, string password)
        {
            try
            {
                var member = GetMemberList().FirstOrDefault(x => x.Email == email && x.Password == password);
                return member;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
