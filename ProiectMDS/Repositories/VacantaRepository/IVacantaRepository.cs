using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.VacantaRepository
{
    public interface IVacantaRepository
    {
        List<Vacanta> GetAll();
        Vacanta Get(int id);
        Vacanta Create(Vacanta Vacanta);
        Vacanta Update(Vacanta Vacanta);
        Vacanta Delete(Vacanta Vacanta);
    }
}
