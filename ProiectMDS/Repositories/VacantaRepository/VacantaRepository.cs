using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.VacantaRepository
{
    public class VacantaRepository:IVacantaRepository
    {
        public Context _context { get; set; }

        public VacantaRepository(Context context)
        {
            _context = context;
        }
        public Vacanta Create(Vacanta vacanta)
        {
            var result = _context.Add<Vacanta>(vacanta);
            _context.SaveChanges();
            return result.Entity;
        }

        public Vacanta Get(int Id)
        {
            return _context.Vacante.SingleOrDefault(x => x.ID == Id);
        }

        public List<Vacanta> GetAll()
        {
            return _context.Vacante.ToList();
        }

        public Vacanta Update(Vacanta vacanta)
        {
            _context.Entry(vacanta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return vacanta;
        }

        public Vacanta Delete(Vacanta vacanta)
        {
            var result = _context.Remove(vacanta);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
