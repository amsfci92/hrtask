
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.DAL.GenericRepository;
using HR.DTO.Task;
using Task = HR.DAL.Task;

namespace HR.BLL.Services.TaskServ 
{
    /// <summary>
    ///  Task Service
    /// </summary>
    public class TaskService : ITaskService
    {
    
        #region Fields
        private IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public TaskVM Create(TaskVM task)
        {
            var mapped = Mapper.Map<Task>(task);
            var entity = _unitOfWork.Task.Add(mapped);
            return Mapper.Map<TaskVM>(entity);
        }

        public bool Delete(int id)
        {
            var exists = _unitOfWork.Task.Get(id);

            if (exists != null)
            {
                var deleted = _unitOfWork.Task.Remove(exists);
                return deleted == 1;
            }
            return false;
        }

        public IEnumerable<TaskVM> GetAllTasks()
        {
            var tasks = _unitOfWork.Task.GetAll();
            return Mapper.Map<IEnumerable<TaskVM>>(tasks);

        }

        public IEnumerable<TaskVM> GetMyTasks(string v)
        {
            var tasks = _unitOfWork.Task.GetAll().Where(m => m.EmployeeId == v).ToList();
            return Mapper.Map<IEnumerable<TaskVM>>(tasks);
        }

        public TaskVM GetTaskById(int id)
        { 
            var task = _unitOfWork.Task.GetAll().Where(m => m.Id == id).FirstOrDefault();
            return Mapper.Map<TaskVM>(task);
        }

        public void Update(TaskVM task)
        {
            var t = Mapper.Map<Task>(task);
            _unitOfWork.Task.Update(t);
        }
        #endregion

        #region Helpers

        #endregion
    }
}

