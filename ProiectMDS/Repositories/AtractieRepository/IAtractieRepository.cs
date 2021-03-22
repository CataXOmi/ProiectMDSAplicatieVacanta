using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.AtractieRepository
{
    public interface IAtractieRepository
    {
        List<Atractie> GetAll();
        Atractie Get(int Id);
        Atractie Create(Atractie Atractie);
        Atractie Update(Atractie Atractie);
        Atractie Delete(Atractie Atractie);
    }
}
