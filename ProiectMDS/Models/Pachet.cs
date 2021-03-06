using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Pachet
    {
        public int ID { get; set; }
        public int CazareID { get; set; }
        public int FacilitateID { get; set; }
        public virtual Cazare Cazare { get; set; }
        public virtual Facilitate Facilitate { get; set; }
    }
}
