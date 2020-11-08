using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL
{
    [MetadataType(typeof(AspNetUserMetaData))]
    public partial class AspNetUser
    {
        public string FullName { 
            get 
            {
                return $"{FirstName} {LastName}";
            } 
            set {}
        }
    }
    public class AspNetUserMetaData
    {
        // validation goes here
    }
}
