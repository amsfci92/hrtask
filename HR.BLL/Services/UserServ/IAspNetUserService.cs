
 

using HR.DAL;
using HR.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.Services.AspNetUserServ 
{
    /// <summary>
    ///  AspNetUser Service Interface
    /// </summary> 

    public interface IAspNetUserService
    {
        #region Fields

        #endregion

        #region Methods 
        IEnumerable<UserVM> GetUsersByManagerId(string v);
        IEnumerable<UserVM> GetUsersEmployeesList(string v = null);
        bool DeleteById(string id);

        #endregion
    }
}

