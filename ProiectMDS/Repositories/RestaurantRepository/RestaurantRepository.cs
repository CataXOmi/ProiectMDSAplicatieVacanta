using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.RestaurantRepository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public Context _context { get; set; }

        public RestaurantRepository(Context context)
        {
            _context = context;
        }

        public Restaurant Create(Restaurant restaurant)
        {
            var result = _context.Add<Restaurant>(restaurant);
            _context.SaveChanges();
            return result.Entity;
        }

        public Restaurant Get(int Id)
        {
            return _context.Restaurante.SingleOrDefault(x => x.ID == Id);
        }

        public List<Restaurant> GetAll()
        {
            return _context.Restaurante.ToList();
        }

        public Restaurant Update(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Delete(Restaurant restaurant)
        {
            var result = _context.Remove(restaurant);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
