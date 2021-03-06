using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class TichetMasa
    {
        public int ID { get; set; }
        public int VacantaID { get; set; }
        public int RestaurantID { get; set; }
        public string CodTichet { get; set; }
        public virtual Vacanta Vacanta { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
