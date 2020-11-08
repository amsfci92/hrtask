
using AutoMapper;
using HR.BLL.Services.AspNetUserServ;
using HR.BLL.Services.TaskServ;
using HR.DTO.Task;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sahab.Enterprise.HR.Controllers
{
    /// <summary>
    /// MAnage the Tasks Operations
    /// </summary>
    [Authorize]
    [RoutePrefix("Task")]
    public class TaskController : Controller
    {
        #region Fields
        private ITaskService _taskService;
        private IAspNetUserService _userService;
        #endregion

        #region Ctor
        public TaskController(ITaskService taskService,
            IAspNetUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }
        #endregion

        #region Method
        /// <summary>
        /// All Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var departments = _taskService.GetAllTasks();
            return View(departments ?? new List<TaskVM>());
        }

        /// <summary>
        /// Create new Task
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        public ActionResult Create()
        { 
            var employees = _userService.GetUsersByManagerId(User.Identity.GetUserId());
            var task = new TaskVM 
            { 
                Employees = Mapper.Map<IEnumerable<SelectListItem>>(employees) 
            };
            return View(task);
        }

        /// <summary>
        /// Create New Task
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public ActionResult Create(TaskVM task)
        {
            if(ModelState.IsValid)
            {
                _taskService.Create(task);
                return RedirectToAction("Index");
            }
            var employees = _userService.GetUsersByManagerId(User.Identity.GetUserId());

            task.Employees = Mapper.Map<IEnumerable<SelectListItem>>(employees);
            return View(task); 
        }

        /// <summary>
        /// Edit Task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            ViewBag.Add = false;
            var tas = _taskService.GetTaskById(id);
            return PartialView("Partials/_Form", tas);
        }

        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(TaskVM task)
        {
            ViewBag.Add = false;
            if (ModelState.IsValid)
            {
                task.UpdateDate = DateTime.Now;
                _taskService.Update(task);
                return Json(new { status = true });
            }
            else
            {
                return HttpNotFound();
            }
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var result = _taskService.Delete(id);
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get My Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MyTasks")]
        public ActionResult GetMyTasks()
        {
            ViewBag.Add = false;
            var tas = _taskService.GetMyTasks(User.Identity.GetUserId());
            return View("MyTasks", tas);
        }
        #endregion

        #region Helper

        #endregion
    }
}
