using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.BiletRepository
{
    public class BiletRepository : IBiletRepository
    {
        public Context _context { get; set; }

        public BiletRepository(Context context)
        {
            _context = context;
        }

        public Bilet Create(Bilet bilet)
        {
            var result = _context.Add<Bilet>(bilet);
            _context.SaveChanges();
            return result.Entity;
        }

        public Bilet Get(int Id)
        {
            return _context.Bilete.SingleOrDefault(x => x.ID == Id);
        }

        public List<Bilet> GetAll()
        {
            return _context.Bilete.ToList();
        }

        public Bilet Update(Bilet bilet)
        {
            _context.Entry(bilet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return bilet;
        }

        public Bilet Delete(Bilet bilet)
        {
            var result = _context.Remove(bilet);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
