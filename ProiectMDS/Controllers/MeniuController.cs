using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.MeniuRepository;
using ProiectMDS.Repositories.RestaurantRepository;
using ProiectMDS.Repositories.MancareRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeniuController : ControllerBase
    {
        public IMeniuRepository IMeniuRepository { get; set; }
        public IRestaurantRepository IRestaurantRepository { get; set; }
        public IMancareRepository IMancareRepository { get; set; }
        public MeniuController(IMeniuRepository meniurepository, IRestaurantRepository restaurantrepository, IMancareRepository mancarerepository)
        {
            IMeniuRepository = meniurepository;
            IRestaurantRepository = restaurantrepository;
            IMancareRepository = mancarerepository;
        }

        // GET: api/<MeniuController>
        [HttpGet]
        public ActionResult<IEnumerable<Meniu>> Get()
        {
            return IMeniuRepository.GetAll();
        }

        // GET api/<MeniuController>/5
        [HttpGet("{id}")]
        public MeniuDetailsDTO Get(int id)
        {
            Meniu meniu = IMeniuRepository.Get(id);
            Restaurant restaurant = IRestaurantRepository.Get(id);
            Mancare mancare = IMancareRepository.Get(id);
            MeniuDetailsDTO MyMeniuDTO = new MeniuDetailsDTO();

            if (meniu != null)
            {
                MyMeniuDTO.MancareDenumire = mancare.Denumire;
                MyMeniuDTO.Pret = meniu.Pret;
                MyMeniuDTO.RestaurantNume = restaurant.Nume;
            }

            return MyMeniuDTO;
        }

        // POST api/<MeniuController>
        [HttpPost]
        public Meniu Post(MeniuDTO value)
        {
            Meniu model = new Meniu()
            {
                Pret = value.Pret,
                RestaurantID = value.RestaurantID,
                MancareID = value.MancareID
            };

            return IMeniuRepository.Create(model);
        }

        // PUT api/<MeniuController>/5
        [HttpPut("{id}")]
        public Meniu Put(int id, MeniuDTO value)
        {
            Meniu model = IMeniuRepository.Get(id);
            if (value.Pret != 0.0)
            {
                model.Pret = value.Pret;
            }

            if (value.MancareID != 0)
            {
                model.MancareID = value.MancareID;
            }

            if (value.RestaurantID != 0)
            {
                model.RestaurantID = value.RestaurantID;
            }

            return IMeniuRepository.Update(model);
        }

        // DELETE api/<MeniuController>/5
        [HttpDelete("{id}")]
        public Meniu Delete(int id)
        {
            Meniu meniu = IMeniuRepository.Get(id);
            return IMeniuRepository.Delete(meniu);
        }
    }
}
