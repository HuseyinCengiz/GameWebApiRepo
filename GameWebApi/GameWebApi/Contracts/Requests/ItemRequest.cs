using GameWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Contracts.Requests
{
    public class ItemRequest
    {
        public Item item { get; set; }

        public ItemResim resim { get; set; }

    }
}
