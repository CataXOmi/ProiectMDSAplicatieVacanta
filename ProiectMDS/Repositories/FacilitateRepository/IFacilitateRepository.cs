using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.FacilitateRepository
{
    public interface IFacilitateRepository
    {
        List<Facilitate> GetAll();
        Facilitate Get(int Id);
        Facilitate Create(Facilitate Facilitate);
        Facilitate Update(Facilitate Facilitate);
        Facilitate Delete(Facilitate Facilitate);
    }
}
