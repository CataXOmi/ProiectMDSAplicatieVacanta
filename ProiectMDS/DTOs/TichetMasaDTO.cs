using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class TichetMasaDTO
    {
        public int VacantaID { get; set; }
        public List<int> RestaurantID { get; set; }
        public List<string> CodTichet { get; set; }
    }
}
