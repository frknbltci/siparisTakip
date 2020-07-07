using hali.BLL.Repository.Service;
using hali.DAL.DB;
using hali.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hali.UI.Controllers
{
    public class OrderController : BaseController
    {
      
        public ActionResult Index()
        {
           
            return View();
        }
        

        [HttpPost]
        public ActionResult addOrder(OrderVM gelen)
        {
            var file = gelen.Resim;
            var fileName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);
            var resimSon = fileName + extension;
            var filenameWithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

            if (file != null)
            {
             
                file.SaveAs(Server.MapPath("~/Images/" + resimSon));
            }
            
            Order siparis = new Order()
            {
                Piece = gelen.Adet,
                OrderDate=gelen.SiparisTarihi,
                Length=gelen.Uzunluk,
                Image="Images/"+ resimSon,
                m2=gelen.M2,
                Width=gelen.Genislik,
                CustomerName=gelen.MusteriAdi,
                ProductCode=gelen.UrunKodu,
                ProductName=gelen.UrunAdi,
                DeliveryDate=gelen.TeslimTarihi,
                Description=gelen.Aciklama,
                CargoCode=gelen.KargoKodu
            };

            service.OrderService.Insert(siparis);


            //Ayarlar kısmı ve gelecek olan değerleri statik ver devam et 


            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult addOrder()
        {

            return View();
        }


    }
}