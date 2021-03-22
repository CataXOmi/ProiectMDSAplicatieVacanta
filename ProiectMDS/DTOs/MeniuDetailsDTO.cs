using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class MeniuDetailsDTO
    {
        public string RestaurantNume { get; set; }
        public List<string> MancareDenumire { get; set; }
        public List<float> Pret { get; set; }
    }
}
