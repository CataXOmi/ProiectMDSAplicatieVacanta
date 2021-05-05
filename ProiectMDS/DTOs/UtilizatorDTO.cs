using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProiectMDS.DTOs
{
    public class UtilizatorDTO
    {
        public string Username { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Parola { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataNasterii { get; set; }
        public List<int> FotografieID { get; set; }
        public List<int> RezervareID { get; set; }

    }
}
