using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.PachetRepository
{
    public class PachetRepository:IPachetRepository
    {
        public Context _context { get; set; }

        public PachetRepository(Context context)
        {
            _context = context;
        }
        public Pachet Create(Pachet pachet)
        {
            var result = _context.Add<Pachet>(pachet);
            _context.SaveChanges();
            return result.Entity;
        }

        public Pachet Get(int Id)
        {
            return _context.Pachete.SingleOrDefault(x => x.ID == Id);
        }

        public List<Pachet> GetAll()
        {
            return _context.Pachete.ToList();
        }

        public Pachet Update(Pachet pachet)
        {
            _context.Entry(pachet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return pachet;
        }

        public Pachet Delete(Pachet pachet)
        {
            var result = _context.Remove(pachet);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
