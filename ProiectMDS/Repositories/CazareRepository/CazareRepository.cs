using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.CazareRepository
{
    public class CazareRepository:ICazareRepository
    {
        public Context _context { get; set; }

        public CazareRepository(Context context)
        {
            _context = context;
        }
        public Cazare Create(Cazare cazare)
        {
            var result = _context.Add<Cazare>(cazare);
            _context.SaveChanges();
            return result.Entity;
        }

        public Cazare Get(int Id)
        {
            return _context.Cazari.SingleOrDefault(x => x.ID == Id);
        }

        public List<Cazare> GetAll()
        {
            return _context.Cazari.ToList();
        }

        public Cazare Update(Cazare cazare)
        {
            _context.Entry(cazare).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return cazare;
        }

        public Cazare Delete(Cazare cazare)
        {
            var result = _context.Remove(cazare);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
