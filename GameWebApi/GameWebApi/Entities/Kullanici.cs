using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Entities
{
    public class Kullanici
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string kullaniciAdi { get; set; }
        public DateTime dogumTarihi { get; set; }
        public string sifre { get; set; }
        public decimal bakiye { get; set; }
    }
}
