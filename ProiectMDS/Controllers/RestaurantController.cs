using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.RestaurantRepository;
using ProiectMDS.Repositories.MeniuRepository;
using ProiectMDS.Repositories.MancareRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        public IRestaurantRepository IRestaurantRepository { get; set; }
        public IMancareRepository IMancareRepository { get; set; }
        public IMeniuRepository IMeniuRepository { get; set; }

        public RestaurantController(IRestaurantRepository repository, IMancareRepository mancareRepository, IMeniuRepository meniuRepository)
        {
            IRestaurantRepository = repository;
            IMeniuRepository = meniuRepository;
            IMancareRepository = mancareRepository;
        }

        // GET: api/<RestaurantController>
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> Get()
        {
            return IRestaurantRepository.GetAll();
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public RestaurantDTO Get(int id)
        {
            Restaurant restaurant = IRestaurantRepository.Get(id);
            RestaurantDTO myRestaurant = new RestaurantDTO();

            if (myRestaurant != null)
            {
                myRestaurant.Adresa = restaurant.Adresa;
                myRestaurant.Nume = restaurant.Nume;
                myRestaurant.OraDeschidere = restaurant.OraDeschidere;
                myRestaurant.OraInchidere = restaurant.OraInchidere;
                myRestaurant.Oras = restaurant.Oras;
            }

            IEnumerable<Meniu> myMeniu = IMeniuRepository.GetAll().Where(x => x.RestaurantID == restaurant.ID);
            List<int> ListaMancare = new List<int>();
            if (myMeniu != null)
            {
                foreach (Meniu mymenu in myMeniu)
                {
                    ListaMancare.Add(mymenu.MancareID);
                }
                //myUtilizator.FotografieID = ListaFotografii;
            }

            IEnumerable<Meniu> myMenus = IMeniuRepository.GetAll().Where(x => x.RestaurantID == restaurant.ID);
            List<string> ListaMancaruri = new List<string>();
            if (myMenus != null)
            {
                foreach (int mancareID in ListaMancare)
                {
                    Mancare mancare = IMancareRepository.Get(mancareID);
                    ListaMancaruri.Add(mancare.Denumire);
                }
            }
            myRestaurant.Meniu = ListaMancaruri.ToList();

            return myRestaurant;

        }

        // POST api/<RestaurantController>
        [HttpPost]
        public Restaurant Post(RestaurantDTO value)
        {
            Restaurant model = new Restaurant()
            {
                Nume = value.Nume,
                OraDeschidere = value.OraDeschidere,
                OraInchidere = value.OraInchidere,
                Oras = value.Oras,
                Adresa = value.Adresa
            };
            return IRestaurantRepository.Create(model);
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public Restaurant Put(int id, RestaurantDTO value)
        {
            Restaurant model = IRestaurantRepository.Get(id);

            if (value.Nume != null)
            {
                model.Nume = value.Nume;
            }

            if (value.OraDeschidere != TimeSpan.Zero)
            {
                model.OraDeschidere = value.OraDeschidere;
            }

            if (value.OraInchidere != TimeSpan.Zero)
            {
                model.OraInchidere = value.OraInchidere;
            }

            if (value.Oras != null)
            {
                model.Oras = value.Oras;
            }

            if (value.Adresa != null)
            {
                model.Adresa = value.Adresa;
            }

            return IRestaurantRepository.Update(model);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public Restaurant Delete(int id)
        {
            Restaurant restaurant = IRestaurantRepository.Get(id);
            return IRestaurantRepository.Delete(restaurant);
        }
    }
}
