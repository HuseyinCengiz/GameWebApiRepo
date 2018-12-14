using GameWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Contracts.Requests
{
    public class OyunRequest
    {
        public Oyun oyun { get; set; }
        public Resim resim { get; set; }
        public Video video { get; set; }
        public int[] kategorilerim { get; set; }

    }
}
