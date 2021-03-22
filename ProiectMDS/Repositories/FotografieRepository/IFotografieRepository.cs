using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.FotografieRepository
{
    public interface IFotografieRepository
    {
        List<Fotografie> GetAll();
        Fotografie Get(int id);
        Fotografie Create(Fotografie Fotografie);
        Fotografie Update(Fotografie Fotografie);
        Fotografie Delete(Fotografie Fotografie);
    }
}
