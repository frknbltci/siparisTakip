using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hali.UI.Models
{
    public class MarketVM
    {
        public int ID { get; set; }

        public string MarketName { get; set; }

        public int ComissionPrice { get; set; }

        public int UserID { get; set; }

    }
}