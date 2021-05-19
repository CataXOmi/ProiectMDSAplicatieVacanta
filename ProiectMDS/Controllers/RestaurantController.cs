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
        public RestaurantDetailsDTO Get(int id)
        {
            Restaurant restaurant = IRestaurantRepository.Get(id);
            RestaurantDetailsDTO myRestaurant = new RestaurantDetailsDTO();

            if (myRestaurant != null)
            {
                myRestaurant.Adresa = restaurant.Adresa;
                myRestaurant.Nume = restaurant.Nume;
                myRestaurant.OraDeschidere = restaurant.OraDeschidere;
                myRestaurant.OraInchidere = restaurant.OraInchidere;
                myRestaurant.Oras = restaurant.Oras;
            }

            IEnumerable<Meniu> myMeniu = IMeniuRepository.GetAll().Where(x => x.RestaurantID == restaurant.ID);
            List<string> ListaMancare = new List<string>();
            List<float> ListaPreturi = new List<float>();
            if (myMeniu != null)
            {
                foreach (Meniu mymenu in myMeniu)
                {
                    Mancare mancare = IMancareRepository.GetAll().SingleOrDefault(x => x.ID == mymenu.MancareID);
                    ListaMancare.Add(mancare.Denumire);
                    ListaPreturi.Add(mymenu.Pret);
                }
                //myUtilizator.FotografieID = ListaFotografii;
            }
            myRestaurant.Meniu = ListaMancare;

            return myRestaurant;

        }

        // POST api/<RestaurantController>
        [HttpPost]
        public void Post(RestaurantDTO value)
        {
            Restaurant model = new Restaurant()
            {
                Nume = value.Nume,
                OraDeschidere = value.OraDeschidere,
                OraInchidere = value.OraInchidere,
                Oras = value.Oras,
                Adresa = value.Adresa
            };
            IRestaurantRepository.Create(model);

            if (value.MeniuID != null)
            {
                for (int i = 0; i < value.MeniuID.Count; i++)
                {
                    Meniu meniu = new Meniu()
                    {
                        RestaurantID = model.ID,
                        MancareID = value.MeniuID[i]
                    };
                    IMeniuRepository.Create(meniu);
                }
            }

        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public void Put(int id, RestaurantDTO value)
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

            IRestaurantRepository.Update(model);

            if (value.MeniuID != null)
            {
                IEnumerable<Meniu> myMeniuri = IMeniuRepository.GetAll().Where(x => x.RestaurantID == id);
                foreach (Meniu myMeniu in myMeniuri)
                    IMeniuRepository.Delete(myMeniu);
                for (int i = 0; i < value.MeniuID.Count; i++)
                {
                    Meniu meniu = new Meniu()
                    {
                        RestaurantID = model.ID,
                        MancareID = value.MeniuID[i]
                    };
                    IMeniuRepository.Create(meniu);
                }
            }
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
