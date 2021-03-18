using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.RestaurantRepository
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetAll();
        Restaurant Get(int Id);
        Restaurant Create(Restaurant Restaurant);
        Restaurant Update(Restaurant Restaurant);
        Restaurant Delete(Restaurant Restaurant);
    }
}
