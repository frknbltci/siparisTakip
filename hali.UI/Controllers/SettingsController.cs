using hali.BLL.Repository.DTO;
using hali.DAL.DB;
using hali.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace hali.UI.Controllers
{
    public class SettingsController : BaseController
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CargoOperations()
        {
            var CargoVerileri = service.CargoService.GetAll().Where(x => x.IsActive == true).ToList();
            return View(CargoVerileri);
        }

        [HttpPost]
        public ActionResult UpdateInfo(CargoVM data)
        {

            var CargoVerileri = service.CargoService.Find(data.ID);
          
            return Json(CargoVerileri.CargoName,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCargoName(CargoVM data)
        {
            Cargo cargo = new Cargo()
            {  
                
                ID=data.ID,
                CargoName = data.CargoName
            };  

            service.CargoService.Update(cargo);

            return Json("OK",JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult InsertCargoName(Cargo data)
        {
            Cargo cargo = new Cargo()
            {
                CargoName = data.CargoName,
                IsActive = data.IsActive,
                UserID = data.UserID
            };
            service.CargoService.Insert(cargo);
            return Json(true,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InActiveEt(int? ID)
        {
            if (ID != null)
            {
                service.CargoService.UpdateIsActive((int)ID);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
          

        }

        [HttpPost]
        public ActionResult ActiveEt(int? ID)
        {
            if (ID != null)
            {
                service.CargoService.UpdateActive((int)ID);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

            //MARKET OPERATIONS
        public ActionResult MarketOperations()
        {
            var marketVerileri = service.MarketService.GetAll().ToList();
            return View(marketVerileri);
        }

        [HttpPost]
        public ActionResult ekleMarket(MarketVM market)
        {
            if (ModelState.IsValid)
            {
                Market m = new Market(){ 
                
                      ComissionPrice=market.ComissionPrice,
                    MarketName=market.MarketName,
                    UserID=market.UserID
                
                };

                service.MarketService.Insert(m);


                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        } 

        //[HttpPost]
        // Düzenleye tıklandığında inputları doldurmaya yarayan controller
        public ActionResult UpdateMarketName(int ID)
        {

            MarketDTO marketVerileri = service.MarketService.Update(ID);

           
            return Json(marketVerileri, JsonRequestBehavior.AllowGet);
        }

        //Dolan inputları tekrar kaydeden controller
        public ActionResult EditMarketName(MarketDTO gelen)
        {
            MarketDTO market = new MarketDTO()
            {
                CommisionPrice = gelen.CommisionPrice,
                MarketName = gelen.MarketName,
                ID = gelen.ID
            };

            service.MarketService.Edit(market);

               return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserOperations()
        {
            return View();
        }

        public ActionResult NotActiveCargo()
        {
            var InActivekargolar = service.CargoService.GetAll().Where(x => x.IsActive == false).ToList();
            return View(InActivekargolar);
        }

    }
}