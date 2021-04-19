using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProiectMDS.DTOs
{
    public class RezervareCazareDetailsDTO
    {
        public string VacantaDenumire { get; set; }
        public string CazareNume { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataSosire { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataPlecare { get; set; }
        public string CodRezervare { get; set; }
    }
}
