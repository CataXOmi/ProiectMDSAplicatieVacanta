using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Bilet
    {
        public int ID { get; set; }
        public int VacantaID { get; set; }
        public int AtractieID { get; set; }
        public string CodBilet { get; set; }
        public virtual Vacanta Vacanta { get; set; }
        public virtual Atractie Atractie { get; set; }
    }
}
