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
            Meniu Meniu = IMeniuRepository.Get(id);
            Restaurant Restaurant = IRestaurantRepository.Get(id);
            Mancare Mancare = IMancareRepository.Get(id);

            MeniuDetailsDTO MyMeniuDTO = new MeniuDetailsDTO()
            {
                Pret = Meniu.Pret
            };

            IEnumerable<Meniu> MyMeniuriRestaurant = IMeniuRepository.GetAll().Where(x => x.RestaurantID == Restaurant.ID);
            if (MyMeniuriRestaurant != null)
            {
                List<string> RestaurantNumeList = new List<string>();
                foreach (Meniu MyMeniuRestaurant in MyMeniuriRestaurant)
                {
                    Restaurant MyRestaurant = IRestaurantRepository.GetAll().SingleOrDefault(x => x.ID == MyMeniuRestaurant.RestaurantID);
                    RestaurantNumeList.Add(MyRestaurant.Nume);
                }
                MyMeniuDTO.RestaurantNume = RestaurantNumeList;
            }

            IEnumerable<Meniu> MyMeniuriMancare = IMeniuRepository.GetAll().Where(x => x.MancareID == Mancare.ID);
            if (MyMeniuriMancare != null)
            {
                List<string> MancareDenumireList = new List<string>();
                foreach (Meniu MyMeniuMancare in MyMeniuriMancare)
                {
                    Mancare MyMancare = IMancareRepository.GetAll().SingleOrDefault(x => x.ID == MyMeniuMancare.MancareID);
                    MancareDenumireList.Add(MyMancare.Denumire);
                }
                MyMeniuDTO.MancareDenumire = MancareDenumireList;
            }

            return MyMeniuDTO;
        }

        // POST api/<MeniuController>
        [HttpPost]
        public void Post(MeniuDTO value)
        {
            Meniu model = new Meniu()
            {
                Pret = value.Pret
            };

            IMeniuRepository.Create(model);
            for (int i = 0; i < value.RestaurantID.Count; i++)
            {
                Meniu MeniuRestaurant = new Meniu()
                {
                    ID = model.ID,
                    RestaurantID = value.RestaurantID[i]
                };

                IMeniuRepository.Create(MeniuRestaurant);
            }

            for (int i = 0; i < value.MancareID.Count; i++)
            {
                Meniu MeniuMancare = new Meniu()
                {
                    ID = model.ID,
                    MancareID = value.MancareID[i]
                };

                IMeniuRepository.Create(MeniuMancare);
            }

        }

        // PUT api/<MeniuController>/5
        [HttpPut("{id}")]
        public void Put(int id, MeniuDTO value)
        {
            Meniu model = IMeniuRepository.Get(id);
            if (value.Pret != 0)
            {
                model.Pret = value.Pret;
            }

            IMeniuRepository.Update(model);

            if (value.RestaurantID != null)
            {
                IEnumerable<Meniu> MyMeniuriRestaurant = IMeniuRepository.GetAll().Where(x => x.RestaurantID == id);
                foreach (Meniu MyMeniuRestaurant in MyMeniuriRestaurant)
                    IMeniuRepository.Delete(MyMeniuRestaurant);
                for (int i = 0; i < value.RestaurantID.Count; i++)
                {
                    Meniu MeniuRestaurant = new Meniu()
                    {
                        ID = model.ID,
                        RestaurantID = value.RestaurantID[i]
                    };
                    IMeniuRepository.Create(MeniuRestaurant);
                }
            }

            if (value.MancareID != null)
            {
                IEnumerable<Meniu> MyMeniuriMancare = IMeniuRepository.GetAll().Where(x => x.MancareID == id);
                foreach (Meniu MyMeniuMancare in MyMeniuriMancare)
                    IMeniuRepository.Delete(MyMeniuMancare);
                for (int i = 0; i < value.MancareID.Count; i++)
                {
                    Meniu MeniuMancare = new Meniu()
                    {
                        ID = model.ID,
                        MancareID = value.MancareID[i]
                    };
                    IMeniuRepository.Create(MeniuMancare);
                }
            }
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
