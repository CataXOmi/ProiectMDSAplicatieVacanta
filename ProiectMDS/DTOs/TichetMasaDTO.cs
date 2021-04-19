using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class TichetMasaDTO
    {
        public int VacantaID { get; set; }
        public int RestaurantID { get; set; }
        public DateTime DataVizita { get; set; }
        public string CodTichet { get; set; }
    }
}
