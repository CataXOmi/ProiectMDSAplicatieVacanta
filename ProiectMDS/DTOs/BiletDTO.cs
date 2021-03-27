using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class BiletDTO
    {
        public List<int> VacantaID { get; set; }
        public List<int> AtractieID { get; set; }
        public string CodBilet { get; set; }
    }
}
