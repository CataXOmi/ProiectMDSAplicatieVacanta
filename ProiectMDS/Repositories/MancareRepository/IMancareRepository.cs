using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.MancareRepository
{
    public interface IMancareRepository
    {
        List<Mancare> GetAll();
        Mancare Get(int Id);
        Mancare Create(Mancare Mancare);
        Mancare Update(Mancare Mancare);
        Mancare Delete(Mancare Mancare);
    }
}
