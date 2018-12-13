using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Entities
{
    public class Oyun
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string aciklama { get; set; }
        public decimal fiyat { get; set; }
        public DateTime cikisTarihi { get; set; }
        public double boyut { get; set; }
        public int yapimciId { get; set; }
    }
}
