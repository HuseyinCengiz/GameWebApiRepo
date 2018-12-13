using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Entities
{
    public class Video
    {
        public int id { get; set; }
        public string url { get; set; }
        public int oyunId { get; set; }
    }
}
