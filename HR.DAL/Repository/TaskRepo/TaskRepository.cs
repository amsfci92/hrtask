
using System;
using System.Collections.Generic;
using HR.DAL;
using HR.DAL.GenericRepository; 

namespace HR.DAL.Repository.TaskRepo 
{
    /// <summary>
    ///  Task Repository
    /// </summary>
    public class TaskRepository : Repository< Task>, ITaskRepository 
    {
    
        #region Fields

        #endregion
        
        #region Ctor
        public TaskRepository (HREntities context) : base(context) { } 
        #endregion

        #region Methods

        #endregion

        #region Helpers

        #endregion
    }
}

