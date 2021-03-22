using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class FotografieDetailsDTO
    {
        public string Titlu { get; set; }
        public DateTime Data { get; set; }
        //relatie Many to Many
        public string UtilizatorUsername { get; set; }
    }
}
