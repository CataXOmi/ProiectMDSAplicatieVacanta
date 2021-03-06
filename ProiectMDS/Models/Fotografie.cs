using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Models
{
    public class Fotografie
    {
        public int ID { get; set; }
        public string Titlu { get; set; }
        public DateTime Data { get; set; }
        public int UtilizatorID { get; set; }
        public virtual Utilizator Utilizator { get; set; }
    }
}
