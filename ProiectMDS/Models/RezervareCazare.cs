using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class RezervareCazare
    {
        public int ID { get; set; }
        public int VacantaID { get; set; }
        public int CazareID { get; set; }
        public string CodRezervare { get; set; }
        public virtual Vacanta Vacanta { get; set; }
        public virtual Cazare Cazare { get; set; }
    }
}
