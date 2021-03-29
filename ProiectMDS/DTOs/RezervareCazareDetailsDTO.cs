using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class RezervareCazareDetailsDTO
    {
        public List<string> VacantaDenumire { get; set; }
        public List<string> CazareNume { get; set; }
        public string CodRezervare { get; set; }
    }
}
