using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMDS.DTOs
{
    public class VacantaDTO
    {
        public string Denumire { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataInceput { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataSfarsit { get; set; }
        public string Oras { get; set; }
        public string Tara { get; set; }
        
        //public List<int> RezervareID { get; set; }
        //public List<int> RezervareCazareID { get; set; }
        //public List<int> BiletID { get; set; }
        //public List<int> TichetMasaID { get; set; }        
        
    }
}
