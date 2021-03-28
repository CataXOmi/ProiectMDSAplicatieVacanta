using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.TichetMasaRepository;
using ProiectMDS.Repositories.VacantaRepository;
using ProiectMDS.Repositories.RestaurantRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TichetMasaController : ControllerBase
    {
        public ITichetMasaRepository ITichetMasaRepository { get; set; }
        public IRestaurantRepository IRestaurantRepository { get; set; }
        public IVacantaRepository IVacantaRepository { get; set; }

        public TichetMasaController (IRestaurantRepository restaurantRepository, IVacantaRepository vacantaRepository, ITichetMasaRepository tichetMasaRepository)
        {
            ITichetMasaRepository = tichetMasaRepository;
            IVacantaRepository = vacantaRepository;
            IRestaurantRepository = restaurantRepository;
        }

        
        // GET: api/<TichetMasaController>
        [HttpGet]
        public ActionResult<IEnumerable<TichetMasa>> Get()
        {
            return ITichetMasaRepository.GetAll();
        }

        // GET api/<TichetMasaController>/5
        [HttpGet("{id}")]
        public TichetMasaDetailsDTO Get(int id)
        {
            TichetMasa tichetMasa = ITichetMasaRepository.Get(id);
            Restaurant restaurant = IRestaurantRepository.Get(id);
            Vacanta vacanta = IVacantaRepository.Get(id);

            TichetMasaDetailsDTO myTichetMasa = new TichetMasaDetailsDTO()
            {
                CodTichet = tichetMasa.CodTichet,
            };

            IEnumerable<TichetMasa> myTicheteMasaRestaurant = ITichetMasaRepository.GetAll().Where(x => x.RestaurantID == restaurant.ID);
            if (myTicheteMasaRestaurant != null)
            {
                List<string> RestaurantNumeList = new List<string>();
                foreach (TichetMasa myTichetMasaRestaurant in myTicheteMasaRestaurant)
                {
                    Restaurant myRestaurant = IRestaurantRepository.GetAll().SingleOrDefault(x => x.ID == myTichetMasaRestaurant.VacantaID);
                    RestaurantNumeList.Add(myRestaurant.Nume);
                }
                myTichetMasa.RestaurantNume = RestaurantNumeList;
            }

            IEnumerable<TichetMasa> MyTicheteMasaVacanta = ITichetMasaRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            if (myTicheteMasaRestaurant != null)
            {
                List<string> VacantaDenumireList = new List<string>();
                foreach (TichetMasa myTichetMasaVacanta in myTicheteMasaRestaurant)
                {
                    Vacanta myVacanta = IVacantaRepository.GetAll().SingleOrDefault(x => x.ID == myTichetMasaVacanta.VacantaID);
                    VacantaDenumireList.Add(myVacanta.Denumire);
                }
                myTichetMasa.VacantaDenumire = VacantaDenumireList;
            }

            return myTichetMasa;
        }

        // POST api/<TichetMasaController>
        [HttpPost]
        public void Post(TichetMasaDTO value)
        {
            TichetMasa model = new TichetMasa()
            {
                CodTichet = value.CodTichet
            };

            ITichetMasaRepository.Create(model);
            for (int i = 0; i < value.VacantaID.Count; i++)
            {
                TichetMasa TichetMasaVacanta = new TichetMasa()
                {
                    ID = model.ID,
                    VacantaID = value.VacantaID[i]
                };

                ITichetMasaRepository.Create(TichetMasaVacanta);
            }

            for (int i = 0; i < value.RestaurantID.Count; i++)
            {
                TichetMasa TichetMasaRestaurant = new TichetMasa()
                {
                    ID = model.ID,
                    RestaurantID = value.RestaurantID[i]
                };

                ITichetMasaRepository.Create(TichetMasaRestaurant);
            }
        }

        // PUT api/<TichetMasaController>/5
        [HttpPut("{id}")]
        public void Put(int id, TichetMasaDTO value)
        {
            TichetMasa model = ITichetMasaRepository.Get(id);
            if (value.CodTichet != null)
            {
                model.CodTichet = value.CodTichet;
            }

            ITichetMasaRepository.Update(model);

            if (value.VacantaID != null)
            {
                IEnumerable<TichetMasa> myTicheteMasaVacanta = ITichetMasaRepository.GetAll().Where(x => x.VacantaID == id);
                foreach (TichetMasa myTichetMasaVacanta in myTicheteMasaVacanta)
                    ITichetMasaRepository.Delete(myTichetMasaVacanta);
                for (int i = 0; i < value.VacantaID.Count; i++)
                {
                    TichetMasa TichetMasaVacanta = new TichetMasa()
                    {
                        ID = model.ID,
                        VacantaID = value.VacantaID[i]
                    };
                    ITichetMasaRepository.Create(TichetMasaVacanta);
                }
            }

            if (value.RestaurantID != null)
            {
                IEnumerable<TichetMasa> myTicheteMasaRestaurant = ITichetMasaRepository.GetAll().Where(x => x.RestaurantID == id);
                foreach (TichetMasa myTichetMasaRestaurant in myTicheteMasaRestaurant)
                    ITichetMasaRepository.Delete(myTichetMasaRestaurant);
                for (int i = 0; i < value.RestaurantID.Count; i++)
                {
                    TichetMasa TichetMasaRestaurant = new TichetMasa()
                    {
                        ID = model.ID,
                        RestaurantID = value.RestaurantID[i]
                    };
                    ITichetMasaRepository.Create(TichetMasaRestaurant);
                }
            }
        }

        // DELETE api/<TichetMasaController>/5
        [HttpDelete("{id}")]
        public TichetMasa Delete(int id)
        {
            TichetMasa tichetMasa = ITichetMasaRepository.Get(id);
            return ITichetMasaRepository.Delete(tichetMasa);
        }
    }
}
