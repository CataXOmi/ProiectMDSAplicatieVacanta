using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.BiletRepository
{
    public interface IBiletRepository
    {
        List<Bilet> GetAll();
        Bilet Get(int Id);
        Bilet Create(Bilet Bilet);
        Bilet Update(Bilet Bilet);
        Bilet Delete(Bilet Bilet);
    }
}
