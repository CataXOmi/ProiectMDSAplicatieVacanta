using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.RezervareCazareRepository
{
    public interface IRezervareCazareRepository
    {
        List<RezervareCazare> GetAll();
        RezervareCazare Get(int id);
        RezervareCazare Create(RezervareCazare RezervareCazare);
        RezervareCazare Update(RezervareCazare RezervareCazare);
        RezervareCazare Delete(RezervareCazare RezervareCazare);
    }
}
