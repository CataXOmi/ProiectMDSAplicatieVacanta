using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class TichetMasaDetailsDTO
    {
        public string VacantaDenumire { get; set; }
        public List<string> RestaurantNume { get; set; }
        public List<string> CodTichet { get; set; }
    }
}
