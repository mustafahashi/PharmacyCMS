using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacyCMS.Models
{
    public class sales
    {
        [Key]
        public int id { get; set; }
        
        public int MedicationID { get; set; }
        public int Medicationprice { get; set; }

        public int discount { get; set; }
        public int price { get; set; }
        // this need to add

    }
}
