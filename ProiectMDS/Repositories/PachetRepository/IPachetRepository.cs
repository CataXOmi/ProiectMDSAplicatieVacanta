using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.PachetRepository
{
    public interface IPachetRepository
    {
        List<Pachet> GetAll();
        Pachet Get(int id);
        Pachet Create(Pachet Pachet);
        Pachet Update(Pachet Pachet);
        Pachet Delete(Pachet Pachet);
    }
}
