using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Entities
{
    public class Item
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string aciklama { get; set; }
        public int oyunId { get; set; }
        public int marketId { get; set; }
        public bool isSilah { get; set; }
        public bool isKiyafet { get; set; }
        public bool isBoost { get; set; }
    }
}
