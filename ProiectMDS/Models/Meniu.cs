using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Meniu
    {
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public int MancareID { get; set; }
        public float Pret { get; set; }
        public virtual Restaurant Restaurant { get; set;  }
        public virtual Mancare Mancare { get; set; }
    }
}
