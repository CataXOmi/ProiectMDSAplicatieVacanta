using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class TichetMasaDetailsDTO
    {
        public List<string> VacantaDenumire { get; set; }
        public List<string> RestaurantNume { get; set; }
        public string CodTichet { get; set; }
    }
}
