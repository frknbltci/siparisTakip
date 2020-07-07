using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hali.UI.Models
{
    public class OrderVM
    {
        public int Adet { get; set; }

        public HttpPostedFileWrapper Resim { get; set; }
        public string Aciklama { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public float M2 { get; set; }
        public float Genislik { get; set; }
        public float Uzunluk { get; set; }
        public string KargoKodu { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public string MusteriAdi { get; set; }


    }
}