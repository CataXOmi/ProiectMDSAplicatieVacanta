using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.UtilizatorRepository
{
    public interface IUtilizatorRepository
    {
        List<Utilizator> GetAll();
        Utilizator Get(int id);
        Utilizator Create(Utilizator Utilizator);
        Utilizator Update(Utilizator Utilizator);
        Utilizator Delete(Utilizator Utilizator);
    }
}
