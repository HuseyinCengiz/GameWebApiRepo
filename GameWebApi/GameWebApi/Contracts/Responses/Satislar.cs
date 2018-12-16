using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Contracts.Responses
{
    public class Satislar
    {
        public int id { get; set; }
        public decimal satisFiyati { get; set; }
        public int itemId { get; set; }
        public string adi { get; set; }
        public string aciklama { get; set; }
        public string url { get; set; }
        public string kullaniciAdi { get; set; }


    }
}
