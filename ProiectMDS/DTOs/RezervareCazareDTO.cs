using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class RezervareCazareDTO
    {
        public List<int> VacantaID { get; set; }
        public List<int> CazareID { get; set; }
        public string CodRezervare { get; set; }
    }
}
