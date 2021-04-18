using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.CazareRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CazareController : ControllerBase
    {
        public ICazareRepository ICazareRepository { get; set; }
        public CazareController(ICazareRepository repository)
        {
            ICazareRepository = repository;
        }

        // GET: api/<CazareController>
        [HttpGet]
        public ActionResult<IEnumerable<Cazare>> Get()
        {
            return ICazareRepository.GetAll();
        }

        // GET api/<CazareController>/5
        [HttpGet("{id}")]
        public ActionResult<Cazare> Get(int id)
        {
            return ICazareRepository.Get(id);
        }

        // POST api/<CazareController>
        [HttpPost]
        public Cazare Post(CazareDTO value)
        {
            Cazare model = new Cazare()
            {
                Nume = value.Nume,
                TipCazare = value.TipCazare,
                Pret = value.Pret,
                Oras = value.Oras,
                Adresa = value.Adresa
            };
            return ICazareRepository.Create(model);
        }

        // PUT api/<CazareController>/5
        [HttpPut("{id}")]
        public Cazare Put(int id, CazareDTO value)
        {
            Cazare model = ICazareRepository.Get(id);
            DateTime? dt = null;

            if (value.Nume != null)
            {
                model.Nume = value.Nume;
            }

            if (value.TipCazare != null)
            {
                model.TipCazare = value.TipCazare;
            }

            if (value.Pret != 0)
            {
                model.Pret = value.Pret;
            }

            if (value.Oras != null)
            {
                model.Oras = value.Oras;
            }

            if (value.Adresa != null)
            {
                model.Adresa = value.Adresa;
            }

            return ICazareRepository.Update(model);
        }

        // DELETE api/<CazareController>/5
        [HttpDelete("{id}")]
        public Cazare Delete(int id)
        {
            Cazare cazare = ICazareRepository.Get(id);
            return ICazareRepository.Delete(cazare);
        }
    }
}
