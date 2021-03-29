using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class MeniuDTO
    {
        public List<int> RestaurantID { get; set; }
        public List<int> MancareID { get; set; }
        public float Pret { get; set; }
    }
}
