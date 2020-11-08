using HR.DTO.Department;
using HR.DTO.Task;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DTO.User
{

    public class UserVM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserVM()
        { 
            this.Managers = new HashSet<UserVM>();
            this.Tasks = new HashSet<TaskVM>();
            this.ManagerTasks = new HashSet<TaskVM>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string ImageUrl { get; set; }
 
        public string ManagerId { get; set; }
        public int? DepartmentId { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<UserVM> Managers { get; set; }
        public virtual UserVM Manager { get; set; }
        public virtual DepartmentVM Department { get; set; }
        public virtual ICollection<TaskVM> Tasks { get; set; }
        public virtual ICollection<TaskVM> ManagerTasks { get; set; }
    }
}
