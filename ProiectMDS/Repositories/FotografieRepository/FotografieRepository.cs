using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.FotografieRepository
{
    public class FotografieRepository:IFotografieRepository
    {
        public Context _context { get; set; }

        public FotografieRepository(Context context)
        {
            _context = context;
        }
        public Fotografie Create(Fotografie fotografie)
        {
            var result = _context.Add<Fotografie>(fotografie);
            _context.SaveChanges();
            return result.Entity;
        }

        public Fotografie Get(int Id)
        {
            return _context.Fotografii.SingleOrDefault(x => x.ID == Id);
        }

        public List<Fotografie> GetAll()
        {
            return _context.Fotografii.ToList();
        }

        public Fotografie Update(Fotografie fotografie)
        {
            _context.Entry(fotografie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return fotografie;
        }

        public Fotografie Delete(Fotografie fotografie)
        {
            var result = _context.Remove(fotografie);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
