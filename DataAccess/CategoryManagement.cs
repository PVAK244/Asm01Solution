using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CategoryManagement
    {
        private static CategoryManagement instance = null;
        private static readonly object instanceLock = new object();

        private CategoryManagement() { }
        public static CategoryManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<CategoryObject> GetCategoryList()
        {
            List<CategoryObject> categorys;
            try
            {
                var fStoreDB = new FStoreContext();
                categorys = fStoreDB.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categorys;
        }
    }
}
