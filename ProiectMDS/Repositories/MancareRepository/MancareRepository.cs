using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.MancareRepository
{
    public class MancareRepository : IMancareRepository
    {
        public Context _context { get; set; }

        public MancareRepository(Context context)
        {
            _context = context;
        }

        public Mancare Create(Mancare mancare)
        {
            var result = _context.Add<Mancare>(mancare);
            _context.SaveChanges();
            return result.Entity;
        }

        public Mancare Get(int Id)
        {
            return _context.Mancaruri.SingleOrDefault(x => x.ID == Id);
        }

        public List<Mancare> GetAll()
        {
            return _context.Mancaruri.ToList();
        }

        public Mancare Update(Mancare mancare)
        {
            _context.Entry(mancare).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return mancare;
        }

        public Mancare Delete(Mancare mancare)
        {
            var result = _context.Remove(mancare);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
