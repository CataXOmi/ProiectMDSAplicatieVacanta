using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectMDS.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan OraDeschidere { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan OraInchidere { get; set; }
        public string Oras { get; set; }
        public string Adresa { get; set; }
        public List<TichetMasa> TichetMasa { get; set; }
        public List<Meniu> Meniu { get; set; }
    }
}
