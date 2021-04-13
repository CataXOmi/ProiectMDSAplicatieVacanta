using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProiectMDS.Models
{
    public class Cazare
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string TipCazare { get; set; }
        public float Pret { get; set; }
        public string Oras { get; set; }
        public string Adresa { get; set; }
        public List<RezervareCazare> RezervareCazare { get; set; }
        public List<Pachet> Pachet { get; set; }
    }
}
