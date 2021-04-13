using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMDS.Models
{
    public class RezervareCazare
    {
        public int ID { get; set; }
        public int VacantaID { get; set; }
        public int CazareID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataSosire { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataPlecare { get; set; }
        public string CodRezervare { get; set; }
        public virtual Vacanta Vacanta { get; set; }
        public virtual Cazare Cazare { get; set; }
    }
}
