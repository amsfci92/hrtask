
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.DAL;
using HR.DAL.GenericRepository;
using HR.DTO.Department;

namespace HR.BLL.Services.DepartmentServ 
{
    /// <summary>
    ///  Department Service
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
    
        #region Fields
        private IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DepartmentVM Add(DepartmentVM department)
        {

            var mapped = Mapper.Map<Department>(department);
            var added = _unitOfWork.Department.Add(mapped);
            return  Mapper.Map<DepartmentVM>(added);

        }

        public bool Delete(int id)
        {
            var dep = _unitOfWork.Department.Get(id);

            if (dep == null)
                return false;

            var result = _unitOfWork.Department.Remove(dep);
            return result == 1;
        }

        public IEnumerable<DepartmentVM> GetAllDepartments()
        {
            var departs = _unitOfWork.Department.GetAll();
            return Mapper.Map<IEnumerable<DepartmentVM>>(departs.ToList());
        }

        public DepartmentVM GetDepartmentById(int id)
        {
            var entity = _unitOfWork.Department.Get(id);
            return Mapper.Map<DepartmentVM>(entity);
        }

        public DepartmentVM Update(DepartmentVM department)
        {
            var mapped = Mapper.Map<Department>(department);
            _unitOfWork.Department.Update(mapped);
            return department;
        }


        #endregion

        #region Methods

        #endregion

        #region Helpers

        #endregion
    }
}

