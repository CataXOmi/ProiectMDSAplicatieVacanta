using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class BiletDetailsDTO
    {
        public string VacantaDenumire { get; set; }
        public List<string> AtractieDenumire { get; set; }
        public List<string> CodBilet { get; set; }
    }
}
