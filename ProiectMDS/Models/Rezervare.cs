﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectMDS.Models
{
    public class Rezervare
    {
        public int ID { get; set; }
        public int UtilizatorID { get; set; }
        public int VacantaID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataRezervare { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public virtual Utilizator Utilizator { get; set; }
        public virtual Vacanta Vacanta { get; set; }
    }
}
