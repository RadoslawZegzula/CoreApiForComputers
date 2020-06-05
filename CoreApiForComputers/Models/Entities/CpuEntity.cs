using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.Models.Entities
{
    public class CpuEntity
    {
        public int Id { get; set; }

        public int Frequency { get; set; }
        public int Cores { get; set; }
        public string Socket { get; set; }
        public float Tdp { get; set; }
    }
}
