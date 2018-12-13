using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Entities
{
    public class Satista
    {
        public int id { get; set; }
        public decimal satisFiyati { get; set; }
        public int itemId { get; set; }
        public int kullaniciId { get; set; }
    }
}
