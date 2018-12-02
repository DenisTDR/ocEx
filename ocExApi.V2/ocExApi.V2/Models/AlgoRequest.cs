using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ocExApi.Models
{
    public class AlgoRequest
    {
        public string Token { get; set; }

        public string Algo { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
