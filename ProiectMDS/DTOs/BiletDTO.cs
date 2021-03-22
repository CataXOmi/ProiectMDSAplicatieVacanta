using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class BiletDTO
    {
        public int VacantaID { get; set; }
        public List<int> AtractieID { get; set; }
        public List<string> CodBilet { get; set; }
    }
}
