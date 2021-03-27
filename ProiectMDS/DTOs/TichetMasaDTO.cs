using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class TichetMasaDTO
    {
        public List<int> VacantaID { get; set; }
        public List<int> RestaurantID { get; set; }
        public string CodTichet { get; set; }
    }
}
