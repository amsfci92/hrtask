using HR.DTO.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DTO.User
{
    public class UserDepartmentVM
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> DepartementId { get; set; }

        public virtual UserVM AspNetUser { get; set; }
        public virtual DepartmentVM Department { get; set; }
    }
}
