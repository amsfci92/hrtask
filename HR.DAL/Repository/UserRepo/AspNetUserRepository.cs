
using System;
using System.Collections.Generic;
using HR.DAL;
using HR.DAL.GenericRepository;
using System.Data.Entity;
using System.Linq;

namespace HR.DAL.Repository.AspNetUserRepo 
{
    /// <summary>
    ///  AspNetUser Repository
    /// </summary>
    public class AspNetUserRepository : Repository< AspNetUser>, IAspNetUserRepository 
    {
    
        #region Fields

        #endregion
        
        #region Ctor
        public AspNetUserRepository (HREntities context) : base(context) { }

        public AspNetUser GetById(string id)
        {
            return _context.AspNetUsers.Where(m => m.Id == id).FirstOrDefault();
        }

        #endregion

        #region Methods

        public IEnumerable<AspNetUser> GetUsersByManagerId(string managerId)
        {
            var query = _context.AspNetUsers
                .Include(m => m.AspNetUser1)
                .Include(m => m.AspNetUsers1)
                .Include(m => m.Tasks);

            // query
            query = query.Where(m => m.ManagerId == managerId);

            return query.ToList();
        }

        public IEnumerable<AspNetUser> GetUsersEmployeesList(string v)
        {
            var query = _context.AspNetUsers
                     .Include(m => m.AspNetUser1)
                     .Include(m => m.AspNetUsers1)
                     .Include(m => m.Tasks);

            if (!string.IsNullOrWhiteSpace(v))
            {
                // query
                query = query.Where(m => m.Id != v);
            }
            return query.ToList();
        }
        #endregion

        #region Helpers

        #endregion
    }
}

