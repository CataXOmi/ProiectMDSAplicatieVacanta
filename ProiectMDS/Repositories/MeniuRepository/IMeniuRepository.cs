using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.MeniuRepository
{
    public interface IMeniuRepository
    {
        List<Meniu> GetAll();
        Meniu Get(int Id);
        Meniu Create(Meniu Meniu);
        Meniu Update(Meniu Meniu);
        Meniu Delete(Meniu Meniu);
    }
}
