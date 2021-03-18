using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.MeniuRepository
{
    public class MeniuRepository : IMeniuRepository
    {
        public Context _context { get; set; }

        public MeniuRepository(Context context)
        {
            _context = context;
        }

        public Meniu Create(Meniu meniu)
        {
            var result = _context.Add<Meniu>(meniu);
            _context.SaveChanges();
            return result.Entity;
        }

        public Meniu Get(int Id)
        {
            return _context.Meniuri.SingleOrDefault(x => x.ID == Id);
        }

        public List<Meniu> GetAll()
        {
            return _context.Meniuri.ToList();
        }

        public Meniu Update(Meniu meniu)
        {
            _context.Entry(meniu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return meniu;
        }

        public Meniu Delete(Meniu meniu)
        {
            var result = _context.Remove(meniu);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
