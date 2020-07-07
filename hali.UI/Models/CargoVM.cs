using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hali.UI.Models
{
    public class CargoVM
    {
        public int ID { get; set; }
        public string CargoName { get; set; }
        
        public bool IsActive { get; set; }

        public int UserID { get; set; }


    }
}