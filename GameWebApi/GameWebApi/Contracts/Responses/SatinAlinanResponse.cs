using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Contracts.Responses
{
    public class SatinAlinanResponse
    {
        public int satinAlinanId { get; set; }
        public int itemId { get; set; }
        public string adi { get; set; }
        public string aciklama { get; set; }
        public string url { get; set; }
    }
}
