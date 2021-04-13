using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMDS.DTOs
{
    public class RezervareDetailsDTO
    {
        public string UtilizatorUsername { get; set; }
        public string VacantaDenumire { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataRezervare { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        [Column(TypeName = "Date")]
        public DateTime VacantaDataInceput { get; set; }
        [Column(TypeName = "Date")]
        public DateTime VacantaDataSfarsit { get; set; }
        public List<string> ListaCazari { get; set; }
        public List<string> ListaAtractii { get; set; }
        public List<string> ListaRestaurante { get; set; }

    }
}
