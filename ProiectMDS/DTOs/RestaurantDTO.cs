using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectMDS.DTOs
{
    public class RestaurantDTO
    {
        public string Nume { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan OraDeschidere { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan OraInchidere { get; set; }
        public string Oras { get; set; }
        public string Adresa { get; set; }
        public List<string> Meniu { get; set; }
        //public List<int> TichetMasaID { get; set; }
    }
}
