using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

/*
https://stackoverflow.com/questions/5658216/entity-framework-code-first-date-field-creation
 */

namespace ProiectMDS.Models
{
    public class Utilizator
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Parola { get; set; }
        [Column(TypeName="Date")]
        public DateTime DataNasterii { get; set; }
        public List<Rezervare> Rezervare { get; set; }
        public List<Fotografie> Fotografie { get; set; }
    }
}
