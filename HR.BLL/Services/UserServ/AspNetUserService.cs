
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.DAL.GenericRepository;
using HR.DTO.User;

namespace HR.BLL.Services.AspNetUserServ 
{
    /// <summary>
    ///  AspNetUser Service
    /// </summary>
    public class AspNetUserService : IAspNetUserService
    {
    
        #region Fields
        private IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public AspNetUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool DeleteById(string id)
        {
            var user = _unitOfWork.AspNetUser.GetById(id);
            var deleted = _unitOfWork.AspNetUser.Remove(user);
            return deleted == 1;
        }


        #endregion

        #region Methods
        /// <summary>
        /// Getting all the employees for some manager
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<UserVM> GetUsersByManagerId(string v)
        {
            var query = _unitOfWork.AspNetUser.GetUsersByManagerId(v);
            var mapped = Mapper.Map<IEnumerable<UserVM>>(query);
            return mapped;
        }

        public IEnumerable<UserVM> GetUsersEmployeesList(string v = null)
        {
            var query = _unitOfWork.AspNetUser.GetUsersEmployeesList(v);
            var mapped = Mapper.Map<IEnumerable<UserVM>>(query);
            return mapped;
        }

        #endregion

        #region Helpers

        #endregion
    }
}

