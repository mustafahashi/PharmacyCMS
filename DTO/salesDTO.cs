using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCMS.DTO
{
    public class salesDTO
    {
        [Key]
        public int id { get; set; }
        public int productID { get; set; }
        public string name { get; set; }

        public int price { get; set; }
        public int discount { get; set; }
        public int finalPrice { get; set; }
    }
}
