using HR.DTO.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DTO.User
{
    public class UserTaskVM
    { 
        public int Id { get; set; }
        public Nullable<long> TaskId { get; set; }
        public string UserId { get; set; }
        public string ManagerId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }

        public virtual UserVM AspNetUser { get; set; }
        public virtual TaskVM Task { get; set; }
    }
}
