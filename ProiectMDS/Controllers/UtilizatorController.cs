using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.UtilizatorRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorController : ControllerBase
    {
        public IUtilizatorRepository IUtilizatorRepository { get; set; }

        public UtilizatorController(IUtilizatorRepository repository)
        {
            IUtilizatorRepository = repository;
        }
        
        // GET: api/<UtilizatorController>
        [HttpGet]
        public ActionResult<IEnumerable<Utilizator>> Get()
        {
            return IUtilizatorRepository.GetAll();
        }

        // GET api/<UtilizatorController>/5
        [HttpGet("{id}")]
        public ActionResult<Utilizator> Get(int id)
        {
            return IUtilizatorRepository.Get(id);
        }

        // POST api/<UtilizatorController>
        [HttpPost]
        public Utilizator Post(UtilizatorDTO value)
        {
            Utilizator model = new Utilizator()
            {
                Username = value.Username,
                Nume = value.Nume,
                Prenume = value.Prenume,
                Email = value.Email,
                Telefon = value.Telefon
            };
            return IUtilizatorRepository.Create(model);
        }

        // PUT api/<UtilizatorController>/5
        [HttpPut("{id}")]
        public Utilizator Put(int id, UtilizatorDTO value)
        {
            Utilizator model = IUtilizatorRepository.Get(id);

            if (value.Username != null)
            {
                model.Username = value.Username;
            }

            if (value.Nume != null)
            {
                model.Nume = value.Nume;
            }

            if (value.Prenume != null)
            {
                model.Prenume = value.Prenume;
            }

            if (value.Email != null)
            {
                model.Email = value.Email;
            }

            if (value.Telefon != null)
            {
                model.Telefon = value.Telefon;
            }

            return IUtilizatorRepository.Update(model);
        }

        // DELETE api/<UtilizatorController>/5
        [HttpDelete("{id}")]
        public Utilizator Delete(int id)
        {
            Utilizator utilizator = IUtilizatorRepository.Get(id);
            return IUtilizatorRepository.Delete(utilizator);
        }
    }
}
