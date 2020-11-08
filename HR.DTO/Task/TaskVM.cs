using HR.DTO.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HR.DTO.Task
{
    public class TaskVM
    {
        public TaskVM()
        {
            this.Employees = new HashSet<SelectListItem>();
        }

        public long Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string EmployeeId { get; set; }

        public string ManagerId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public short StatusCode { get; set; }

        public virtual UserVM Employee { get; set; }
        public virtual UserVM Manager { get; set; } 

        public IEnumerable<SelectListItem> Employees { get; set; }
    }
}
