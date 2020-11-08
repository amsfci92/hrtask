
 

using System;
using System.Collections.Generic;
using HR.DAL;
using HR.DAL.GenericRepository; 

namespace HR.DAL.Repository.AspNetUserRepo 
{
    /// <summary>
    ///  AspNetUser Repository Interface
    /// </summary> 

    public interface IAspNetUserRepository : IRepository<AspNetUser>
    {
        #region Fields

        #endregion

        #region Ctor

        #endregion

        #region Methods 
        IEnumerable<AspNetUser> GetUsersByManagerId(string managerId);
        IEnumerable<AspNetUser> GetUsersEmployeesList(string v);
        AspNetUser GetById(string id);
        #endregion
    }
}
