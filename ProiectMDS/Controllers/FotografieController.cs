using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.FotografieRepository;
using ProiectMDS.Repositories.UtilizatorRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotografieController : ControllerBase
    {
        public IFotografieRepository IFotografieRepository { get; set; }
        public IUtilizatorRepository IUtilizatorRepository { get; set; }
        public FotografieController(IFotografieRepository fotografierepository, IUtilizatorRepository utilizatorrepository)
        {
            IFotografieRepository = fotografierepository;
            IUtilizatorRepository = utilizatorrepository;
        }
        // GET: api/<FotografieController>
        [HttpGet]
        public ActionResult<IEnumerable<Fotografie>> Get()
        {
            return IFotografieRepository.GetAll();
        }

        // GET api/<FotografieController>/5
        [HttpGet("{id}")]
        public FotografieDetailsDTO Get(int id)
        {
            Fotografie Fotografie = IFotografieRepository.Get(id);
            Utilizator Utilizator = IUtilizatorRepository.Get(id);

            FotografieDetailsDTO MyFotografieDTO = new FotografieDetailsDTO()
            {
                Titlu = Fotografie.Titlu,
                Data = Fotografie.Data
            };

            IEnumerable<Fotografie> MyFotografiiUtilizator = IFotografieRepository.GetAll().Where(x => x.UtilizatorID == Utilizator.ID);
            if (MyFotografiiUtilizator != null)
            {
                List<string> UtilizatorUsernameList = new List<string>();
                foreach (Fotografie MyFotografieUtilizator in MyFotografiiUtilizator)
                {
                    Utilizator MyUtilizator= IUtilizatorRepository.GetAll().SingleOrDefault(x => x.ID == MyFotografieUtilizator.UtilizatorID);
                    UtilizatorUsernameList.Add(MyUtilizator.Username);
                }
                MyFotografieDTO.UtilizatorUsername = UtilizatorUsernameList;
            }

            return MyFotografieDTO;
        }

        // POST api/<FotografieController>
        [HttpPost]
        public Fotografie Post(FotografieDTO value)
        {
            Fotografie model = new Fotografie()
            {
                Titlu = value.Titlu,
                Data = value.Data,
                UtilizatorID = value.UtilizatorID
            };

            return IFotografieRepository.Create(model);

        }

        // PUT api/<FotografieController>/5
        [HttpPut("{id}")]
        public Fotografie Put(int id, FotografieDTO value)
        {
            Fotografie model = IFotografieRepository.Get(id);
            DateTime? dt = null;
            if (value.Titlu != null)
            {
                model.Titlu = value.Titlu;
            }

            if (value.Data != dt)
            {
                model.Data = value.Data;
            }

            if (value.UtilizatorID != 0)
            {
                model.UtilizatorID = value.UtilizatorID;
            }

            return IFotografieRepository.Update(model);

        }

        // DELETE api/<FotografieController>/5
        [HttpDelete("{id}")]
        public Fotografie Delete(int id)
        {
            Fotografie fotografie = IFotografieRepository.Get(id);
            return IFotografieRepository.Delete(fotografie);
        }
    }
}
