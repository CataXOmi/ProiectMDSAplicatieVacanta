using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.TichetMasaRepository
{
    public interface ITichetMasaRepository
    {
        List<TichetMasa> GetAll();
        TichetMasa Get(int Id);
        TichetMasa Create(TichetMasa TichetMasa);
        TichetMasa Update(TichetMasa TichetMasa);
        TichetMasa Delete(TichetMasa TichetMasa);
    }
}
