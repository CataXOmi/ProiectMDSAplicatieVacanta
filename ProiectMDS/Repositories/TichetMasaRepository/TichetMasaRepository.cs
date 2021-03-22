using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.TichetMasaRepository
{
    public class TichetMasaRepository : ITichetMasaRepository
    {
        public Context _context { get; set; }

        public TichetMasaRepository(Context context)
        {
            _context = context;
        }

        public TichetMasa Create(TichetMasa tichetMasa)
        {
            var result = _context.Add<TichetMasa>(tichetMasa);
            _context.SaveChanges();
            return result.Entity;
        }

        public TichetMasa Get(int Id)
        {
            return _context.TicheteMasa.SingleOrDefault(x => x.ID == Id);
        }

        public List<TichetMasa> GetAll()
        {
            return _context.TicheteMasa.ToList();
        }

        public TichetMasa Update(TichetMasa tichetMasa)
        {
            _context.Entry(tichetMasa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return tichetMasa;
        }

        public TichetMasa Delete(TichetMasa tichetMasa)
        {
            var result = _context.Remove(tichetMasa);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
