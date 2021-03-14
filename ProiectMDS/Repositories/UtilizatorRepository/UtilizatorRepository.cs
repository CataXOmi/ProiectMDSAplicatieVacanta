using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.UtilizatorRepository
{
    public class UtilizatorRepository:IUtilizatorRepository
    {
        public Context _context { get; set; }

        public UtilizatorRepository(Context context)
        {
            _context = context;
        }
        public Utilizator Create(Utilizator utilizator)
        {
            var result = _context.Add<Utilizator>(utilizator);
            _context.SaveChanges();
            return result.Entity;
        }

        public Utilizator Get(int Id)
        {
            return _context.Utilizatori.SingleOrDefault(x => x.ID == Id);
        }

        public List<Utilizator> GetAll()
        {
            return _context.Utilizatori.ToList();
        }

        public Utilizator Update(Utilizator utilizator)
        {
            _context.Entry(utilizator).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return utilizator;
        }

        public Utilizator Delete(Utilizator utilizator)
        {
            var result = _context.Remove(utilizator);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
