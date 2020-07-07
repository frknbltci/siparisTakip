using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hali.BLL.Repository.DTO
{
   public class MarketDTO
    {
        public int ID { get; set; }
        public string MarketName { get; set; }
        public int CommisionPrice { get; set; }
        public int UserID { get; set; }

    }
}
