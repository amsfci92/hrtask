


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
    public interface IUnitOfWork
    {
        IAspNetUserRepository AspNetUser { get; }
        IDepartmentRepository Department { get; }
        ITaskRepository Task { get; }

    }
} 