using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacy.DTO
{
    public class RegisterationDTO
    {
        public string  MedicationID { get; set; }
        public string MedicationName { get; set; }
        public string MedicationPrice { get; set; }
        public string Discount { get; set; }
        public int FinalPrice { get; set; }



    }
}
