using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy.DTO
{
    public class login
    {
     [Key]
        public int id { get; set; }

        public string username { get; set; }
   
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]

         
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
