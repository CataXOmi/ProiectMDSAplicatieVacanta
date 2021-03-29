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
            Bilet Bilet = IBiletRepository.Get(id);
            Vacanta Vacanta = IVacantaRepository.Get(id);
            Atractie Atractie = IAtractieRepository.Get(id);

            BiletDetailsDTO MyBiletDTO = new BiletDetailsDTO()
            {
                CodBilet = Bilet.CodBilet
            };

            IEnumerable<Bilet> MyBileteVacanta = IBiletRepository.GetAll().Where(x => x.VacantaID == Vacanta.ID);
            if (MyBileteVacanta != null)
            {
                List<string> VacantaDenumireList = new List<string>();
                foreach (Bilet MyBiletVacanta in MyBileteVacanta)
                {
                    Vacanta MyVacanta = IVacantaRepository.GetAll().SingleOrDefault(x => x.ID == MyBiletVacanta.VacantaID);
                    VacantaDenumireList.Add(MyVacanta.Denumire);
                }
                MyBiletDTO.VacantaDenumire = VacantaDenumireList;
            }

            IEnumerable<Bilet> MyBileteAtractie = IBiletRepository.GetAll().Where(x => x.AtractieID == Atractie.ID);
            if (MyBileteAtractie != null)
            {
                List<string> AtractieDenumireList = new List<string>();
                foreach (Bilet MyBiletAtractie in MyBileteAtractie)
                {
                    Atractie MyAtractie = IAtractieRepository.GetAll().SingleOrDefault(x => x.ID == MyBiletAtractie.AtractieID);
                    AtractieDenumireList.Add(MyAtractie.Denumire);
                }
                MyBiletDTO.AtractieDenumire = AtractieDenumireList;
            }

            return MyBiletDTO;
        }

        // POST api/<BiletController>
        [HttpPost]
        public void Post(BiletDTO value)
        {
            Bilet model = new Bilet()
            {
                CodBilet = value.CodBilet
            };

            IBiletRepository.Create(model);
            for (int i = 0; i < value.VacantaID.Count; i++)
            {
                Bilet BiletVacanta = new Bilet()
                {
                    ID = model.ID,
                    VacantaID = value.VacantaID[i]
                };

                IBiletRepository.Create(BiletVacanta);
            }

            for (int i = 0; i < value.AtractieID.Count; i++)
            {
                Bilet BiletAtractie = new Bilet()
                {
                    ID = model.ID,
                    AtractieID = value.AtractieID[i]
                };

                IBiletRepository.Create(BiletAtractie);
            }

        }

        // PUT api/<BiletController>/5
        [HttpPut("{id}")]
        public void Put(int id, BiletDTO value)
        {
            Bilet model = IBiletRepository.Get(id);
            if (value.CodBilet != null)
            {
                model.CodBilet = value.CodBilet;
            }

            IBiletRepository.Update(model);

            if (value.VacantaID != null)
            {
                IEnumerable<Bilet> MyBileteVacanta = IBiletRepository.GetAll().Where(x => x.VacantaID == id);
                foreach (Bilet MyBiletVacanta in MyBileteVacanta)
                    IBiletRepository.Delete(MyBiletVacanta);
                for (int i = 0; i < value.VacantaID.Count; i++)
                {
                    Bilet BiletVacanta = new Bilet()
                    {
                        ID = model.ID,
                        VacantaID = value.VacantaID[i]
                    };
                    IBiletRepository.Create(BiletVacanta);
                }
            }

            if (value.AtractieID != null)
            {
                IEnumerable<Bilet> MyBileteAtractie = IBiletRepository.GetAll().Where(x => x.AtractieID == id);
                foreach (Bilet MyBiletAtractie in MyBileteAtractie)
                    IBiletRepository.Delete(MyBiletAtractie);
                for (int i = 0; i < value.AtractieID.Count; i++)
                {
                    Bilet BiletAtractie = new Bilet()
                    {
                        ID = model.ID,
                        AtractieID = value.AtractieID[i]
                    };
                    IBiletRepository.Create(BiletAtractie);
                }
            }
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
