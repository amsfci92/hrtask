
 

using HR.DAL;
using HR.DTO.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.Services.DepartmentServ 
{
    /// <summary>
    ///  Department Service Interface
    /// </summary> 

    public interface IDepartmentService
    {
        #region Fields

        #endregion

        #region Methods 
        #endregion
        IEnumerable<DepartmentVM> GetAllDepartments();
        DepartmentVM Add(DepartmentVM department);
        DepartmentVM Update(DepartmentVM department);
        bool Delete(int id);
        DepartmentVM GetDepartmentById(int id);
    }
}