using hali.BLL.Repository.DTO;
using hali.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hali.BLL.Repository.Entity
{
   public class MarketRepository:Base.BaseRepository<Market>
    {

        public MarketDTO Update(int ID)
        {
            MarketDTO bulunan = (from mar in GetAll()
                           where mar.ID == ID
                           select new MarketDTO
                           {
                               CommisionPrice = (int)mar.ComissionPrice,
                               MarketName = mar.MarketName,
                               ID = mar.ID,
                           }).SingleOrDefault();
            return bulunan;
            
        }

       

        public void  Edit (MarketDTO market)
        {
            Market m = Find((int)market.ID);
            m.MarketName = market.MarketName;
            m.ComissionPrice = market.CommisionPrice;
            Save();

        }
    }
}
