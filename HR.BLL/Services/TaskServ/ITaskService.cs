
 

using HR.DAL;
using HR.DTO.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.Services.TaskServ 
{
    /// <summary>
    ///  Task Service Interface
    /// </summary> 

    public interface ITaskService
    {
        #region Fields

        #endregion

        #region Methods 
        TaskVM Create(TaskVM task);
        IEnumerable<TaskVM> GetMyTasks(string v);
        IEnumerable<TaskVM> GetAllTasks();
        void Update(TaskVM task);
        TaskVM GetTaskById(int id);
        bool Delete(int id);
        #endregion
    }
}
