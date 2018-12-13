using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Entities
{
    public class Yapimci
    {
        public int id { get; set; }
        public string adi { get; set; }
        public DateTime kurulusTarihi { get; set; }
        public string slogan { get; set; }
    }
}
