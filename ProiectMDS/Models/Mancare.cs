using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Mancare
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public List<Meniu> Meniu { get; set; }
    }
}
