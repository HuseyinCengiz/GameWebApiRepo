using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Entities
{
    public class OyunKullanici
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int oyunId { get; set; }
    }
}
