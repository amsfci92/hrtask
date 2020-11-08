using HR.DTO.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DTO.Department
{
    public class DepartmentVM
    {
        public DepartmentVM()
        {
            this.Users = new HashSet<UserVM>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public bool CanDelete { get { return !Users.Any(); } set { } }

        public virtual ICollection<UserVM> Users { get; set; }
    }
}
