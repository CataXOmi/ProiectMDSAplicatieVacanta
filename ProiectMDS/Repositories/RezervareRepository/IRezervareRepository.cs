using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.RezervareRepository
{
    public interface IRezervareRepository
    {
        List<Rezervare> GetAll();
        Rezervare Get(int id);
        Rezervare Create(Rezervare Rezervare);
        Rezervare Update(Rezervare Rezervare);
        Rezervare Delete(Rezervare Rezervare);
    }
}
