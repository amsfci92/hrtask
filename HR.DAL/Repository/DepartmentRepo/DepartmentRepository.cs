
using System;
using System.Collections.Generic;
using HR.DAL;
using HR.DAL.GenericRepository; 

namespace HR.DAL.Repository.DepartmentRepo 
{
    /// <summary>
    ///  Department Repository
    /// </summary>
    public class DepartmentRepository : Repository< Department>, IDepartmentRepository 
    {
    
        #region Fields

        #endregion
        
        #region Ctor
        public DepartmentRepository (HREntities context) : base(context) { } 
        #endregion

        #region Methods

        #endregion

        #region Helpers

        #endregion
    }
}

