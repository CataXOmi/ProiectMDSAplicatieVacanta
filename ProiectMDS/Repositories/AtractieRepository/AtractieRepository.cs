using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.AtractieRepository
{
    public class AtractieRepository : IAtractieRepository
    {
        public Context _context { get; set; }

        public AtractieRepository(Context context)
        {
            _context = context;
        }

        public Atractie Create(Atractie atractie)
        {
            var result = _context.Add<Atractie>(atractie);
            _context.SaveChanges();
            return result.Entity;
        }

        public Atractie Get(int Id)
        {
            return _context.Atractii.SingleOrDefault(x => x.ID == Id);
        }

        public List<Atractie> GetAll()
        {
            return _context.Atractii.ToList();
        }

        public Atractie Update(Atractie atractie)
        {
            _context.Entry(atractie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return atractie;
        }

        public Atractie Delete(Atractie atractie)
        {
            var result = _context.Remove(atractie);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
