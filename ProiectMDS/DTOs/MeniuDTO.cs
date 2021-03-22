using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class MeniuDTO
    {
        public int RestaurantID { get; set; }
        public List<int> MancareID { get; set; }
        public List<float> Pret { get; set; }
    }
}
