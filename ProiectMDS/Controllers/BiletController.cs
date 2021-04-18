using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.BiletRepository;
using ProiectMDS.Repositories.VacantaRepository;
using ProiectMDS.Repositories.AtractieRepository;



namespace ProiectMDS.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BiletController : ControllerBase
    {
        public IBiletRepository IBiletRepository { get; set; }
        public IVacantaRepository IVacantaRepository { get; set; }
        public IAtractieRepository IAtractieRepository { get; set; }
        public BiletController(IBiletRepository biletrepository, IVacantaRepository vacantarepository, IAtractieRepository atractierepository)
        {
            IBiletRepository = biletrepository;
            IVacantaRepository = vacantarepository;
            IAtractieRepository = atractierepository;
        }

        // GET: api/<BiletController>
        [HttpGet]
        public ActionResult<IEnumerable<Bilet>> Get()
        {
            return IBiletRepository.GetAll();
        }

        // GET api/<BiletController>/5
        [HttpGet("{id}")]
        public BiletDetailsDTO Get(int id)
        {
            Bilet bilet = IBiletRepository.Get(id);
            Vacanta vacanta = IVacantaRepository.Get(bilet.VacantaID);
            Atractie atractie = IAtractieRepository.Get(bilet.AtractieID);
            BiletDetailsDTO bil = new BiletDetailsDTO();

            if (bilet != null)
            {
                bil.CodBilet = bilet.CodBilet;
                bil.AtractieDenumire = atractie.Denumire;
                bil.DataVizita = bilet.DataVizita;
                bil.VacantaDenumire = vacanta.Denumire;
            }

            return bil;
        }

        // POST api/<BiletController>
        [HttpPost]
        public Bilet Post(BiletDTO value)
        {
            Bilet model = new Bilet()
            {
                CodBilet = value.CodBilet,
                DataVizita = value.DataVizita,
                VacantaID = value.VacantaID,
                AtractieID = value.AtractieID

            };

            return IBiletRepository.Create(model);

        }

        // PUT api/<BiletController>/5
        [HttpPut("{id}")]
        public Bilet Put(int id, BiletDTO value)
        {
            Bilet model = IBiletRepository.Get(id);
            DateTime? dt = null;
            if (value.AtractieID != 0)
            {
                model.AtractieID = value.AtractieID;
            }

            if (value.CodBilet != null)
            {
                model.CodBilet = value.CodBilet;
            }

            if (value.DataVizita != dt)
            {
                model.DataVizita = value.DataVizita;
            }

            if (value.VacantaID != 0)
            {
                model.VacantaID = value.VacantaID;
            }

            return IBiletRepository.Update(model);
        }

        // DELETE api/<BiletController>/5
        [HttpDelete("{id}")]
        public Bilet Delete(int id)
        {
            Bilet bilet = IBiletRepository.Get(id);
            return IBiletRepository.Delete(bilet);
        }
    }
}
