using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.RezervareCazareRepository
{
    public class RezervareCazareRepository:IRezervareCazareRepository
    {
        public Context _context { get; set; }

        public RezervareCazareRepository(Context context)
        {
            _context = context;
        }
        public RezervareCazare Create(RezervareCazare rezervareCazare)
        {
            var result = _context.Add<RezervareCazare>(rezervareCazare);
            _context.SaveChanges();
            return result.Entity;
        }

        public RezervareCazare Get(int Id)
        {
            return _context.RezervariCazari.SingleOrDefault(x => x.ID == Id);
        }

        public List<RezervareCazare> GetAll()
        {
            return _context.RezervariCazari.ToList();
        }

        public RezervareCazare Update(RezervareCazare rezervareCazare)
        {
            _context.Entry(rezervareCazare).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return rezervareCazare;
        }

        public RezervareCazare Delete(RezervareCazare rezervareCazare)
        {
            var result = _context.Remove(rezervareCazare);
            _context.SaveChanges();
            return result.Entity;
        }

    }
}
