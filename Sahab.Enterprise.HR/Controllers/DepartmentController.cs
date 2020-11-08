using HR.BLL.Services.DepartmentServ;
using HR.DTO.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sahab.Enterprise.HR.Controllers
{
    [RoutePrefix("Department")]
    public class DepartmentController : Controller
    {
        #region Fields
        private IDepartmentService _departmentService;
        #endregion

        #region Ctor
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Departmnt
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments ?? new List<DepartmentVM>());
        }
         
        /// <summary>
        /// Add Department
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        public ActionResult Create()
        {
            ViewBag.Add = true;
            return PartialView("Partials/_Form");
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Create(DepartmentVM department)
        {
            if (ModelState.IsValid)
            {
                department.CreateDate = DateTime.Now;
                DepartmentVM dep = _departmentService.Add(department);
                return PartialView("Partials/_DepartmentRow", dep);
            }
            else
            {
                return HttpNotFound();
            }
        }

        /// <summary>
        /// Edit Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ViewBag.Add = false;
            var dep = _departmentService.GetDepartmentById(id);
            return PartialView("Partials/_Form", dep);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentVM department)
        {
            ViewBag.Add = false;
            if (ModelState.IsValid)
            {
                DepartmentVM dep = _departmentService.Update(department);
                return PartialView("Partials/_DepartmentRow", dep);
            }
            else
            {
                return HttpNotFound();
            }
        }
         
        /// <summary>
        /// Delete Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var result = _departmentService.Delete(id);
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
