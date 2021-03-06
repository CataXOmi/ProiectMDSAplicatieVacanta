using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectMDS.Models
{
    public class Atractie
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan OraDeschidere { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan OraInchidere { get; set; }
        public float Pret { get; set; }
        public string Oras { get; set; }
        public string Adresa { get; set; }
        public List<Bilet> Bilet { get; set; }
    }
}
