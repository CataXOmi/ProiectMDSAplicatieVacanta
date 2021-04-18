using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class BiletDTO
    {
        public int VacantaID { get; set; }
        public int AtractieID { get; set; }
        public string CodBilet { get; set; }
        public DateTime DataVizita { get; set; }
    }
}
