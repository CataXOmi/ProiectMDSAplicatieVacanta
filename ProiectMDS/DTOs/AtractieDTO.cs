using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectMDS.DTOs
{
    public class AtractieDTO
    {
        public string Denumire { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan OraDeschidere { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan OraInchidere { get; set; }
        public float Pret { get; set; }
        public string Oras { get; set; }
        public string Adresa { get; set; }
    }
}
