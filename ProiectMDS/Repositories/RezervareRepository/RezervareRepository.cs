using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.RezervareRepository
{
    public class RezervareRepository:IRezervareRepository
    {
        public Context _context { get; set; }

        public RezervareRepository(Context context)
        {
            _context = context;
        }
        public Rezervare Create(Rezervare rezervare)
        {
            var result = _context.Add<Rezervare>(rezervare);
            _context.SaveChanges();
            return result.Entity;
        }

        public Rezervare Get(int Id)
        {
            return _context.Rezervari.SingleOrDefault(x => x.ID == Id);
        }

        public List<Rezervare> GetAll()
        {
            return _context.Rezervari.ToList();
        }

        public Rezervare Update(Rezervare rezervare)
        {
            _context.Entry(rezervare).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return rezervare;
        }

        public Rezervare Delete(Rezervare rezervare)
        {
            var result = _context.Remove(rezervare);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
