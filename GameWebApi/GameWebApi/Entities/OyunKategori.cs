using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Entities
{
    public class OyunKategori
    {
        public int id { get; set; }
        public int oyunId { get; set; }
        public int kategoriId { get; set; }
    }
}
