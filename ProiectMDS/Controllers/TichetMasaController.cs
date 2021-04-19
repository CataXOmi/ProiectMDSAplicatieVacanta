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
            Restaurant restaurant = IRestaurantRepository.Get(tichetMasa.RestaurantID);
            Vacanta vacanta = IVacantaRepository.Get(tichetMasa.VacantaID);

            TichetMasaDetailsDTO myTichetMasa = new TichetMasaDetailsDTO();

            if (tichetMasa != null)
            {
                myTichetMasa.CodTichet = tichetMasa.CodTichet;
                myTichetMasa.DataVizita = tichetMasa.DataVizita;
                myTichetMasa.RestaurantNume = restaurant.Nume;
                myTichetMasa.VacantaDenumire = vacanta.Denumire;
            }

            return myTichetMasa;
        }

        // POST api/<TichetMasaController>
        [HttpPost]
        public TichetMasa Post(TichetMasaDTO value)
        {
            TichetMasa model = new TichetMasa()
            {
                DataVizita = value.DataVizita,
                CodTichet = value.CodTichet,
                VacantaID = value.VacantaID,
                RestaurantID = value.RestaurantID
            };

            return ITichetMasaRepository.Create(model);
         }

        // PUT api/<TichetMasaController>/5
        [HttpPut("{id}")]
        public TichetMasa Put(int id, TichetMasaDTO value)
        {
            TichetMasa model = ITichetMasaRepository.Get(id);
            DateTime? dt = null;

            if (value.CodTichet != null)
            {
                model.CodTichet = value.CodTichet;
            }

            if (value.DataVizita != dt)
            {
                model.DataVizita = value.DataVizita;
            }

            if (value.RestaurantID != 0)
            {
                model.RestaurantID = value.RestaurantID;
            }

            if (value.VacantaID != 0)
            {
                model.VacantaID = value.VacantaID;
            }

            return ITichetMasaRepository.Update(model);

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
