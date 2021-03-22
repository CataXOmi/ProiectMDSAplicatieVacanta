using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.FacilitateRepository
{
    public class FacilitateRepository : IFacilitateRepository
    {
        public Context _context { get; set; }

        public FacilitateRepository(Context context)
        {
            _context = context;
        }

        public Facilitate Create(Facilitate facilitate)
        {
            var result = _context.Add<Facilitate>(facilitate);
            _context.SaveChanges();
            return result.Entity;
        }

        public Facilitate Get(int Id)
        {
            return _context.Facilitati.SingleOrDefault(x => x.ID == Id);
        }

        public List<Facilitate> GetAll()
        {
            return _context.Facilitati.ToList();
        }

        public Facilitate Update(Facilitate facilitate)
        {
            _context.Entry(facilitate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return facilitate;
        }

        public Facilitate Delete(Facilitate facilitate)
        {
            var result = _context.Remove(facilitate);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
