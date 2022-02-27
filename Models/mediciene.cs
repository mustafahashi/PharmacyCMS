using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacyCMS.Models
{
    public class mediciene
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }




    }
}
