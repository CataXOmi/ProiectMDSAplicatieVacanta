using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMDS.Models
{
    public class Vacanta
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataInceput { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataSfarsit { get; set; }
        public string Oras { get; set; }
        public string Tara { get; set; }
        public List<Rezervare> Rezervare { get; set; }
        public List<TichetMasa> TichetMasa { get; set; }
        public List<Bilet> Bilet { get; set; }
        public List<RezervareCazare> RezervareCazare { get; set; }

    }
}
