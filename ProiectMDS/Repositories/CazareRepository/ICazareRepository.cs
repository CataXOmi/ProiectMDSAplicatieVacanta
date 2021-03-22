using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.CazareRepository
{
    public interface ICazareRepository
    {
        List<Cazare> GetAll();
        Cazare Get(int id);
        Cazare Create(Cazare Cazare);
        Cazare Update(Cazare Cazare);
        Cazare Delete(Cazare Cazare);
    }
}
