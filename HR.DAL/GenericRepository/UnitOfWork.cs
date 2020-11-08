using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Repos  
using HR.DAL.Repository.AspNetUserRepo;
using HR.DAL.Repository.DepartmentRepo;
using HR.DAL.Repository.TaskRepo;

namespace HR.DAL.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private HREntities _context;
        private IAspNetUserRepository _aspnetuser;
        private IDepartmentRepository _department;
        private ITaskRepository _task;
        #endregion

        #region Ctor
        public UnitOfWork(
            IAspNetUserRepository aspnetuser,
            IDepartmentRepository department,
            ITaskRepository task
            )
        {
            _aspnetuser = aspnetuser;
            _department = department;
            _task = task;
        }
        #endregion

        #region Properties 
        public IAspNetUserRepository AspNetUser { get { return _aspnetuser; } }
        public IDepartmentRepository Department { get { return _department; } }
        public ITaskRepository Task { get { return _task; } }

        #endregion
    }
}


