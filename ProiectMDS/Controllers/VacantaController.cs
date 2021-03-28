using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.VacantaRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacantaController : ControllerBase
    {
        public IVacantaRepository IVacantaRepository { get; set; }

        public VacantaController (IVacantaRepository repository)
        {
            IVacantaRepository = repository;
        }
        // GET: api/<VacantaController>
        [HttpGet]
        public ActionResult<IEnumerable<Vacanta>> Get()
        {
            return IVacantaRepository.GetAll();
        }

        // GET api/<VacantaController>/5
        [HttpGet("{id}")]
        public ActionResult<Vacanta> Get(int id)
        {
            return IVacantaRepository.Get(id);
        }

        // POST api/<VacantaController>
        [HttpPost]
        public Vacanta Post(VacantaDTO value)
        {
            Vacanta model = new Vacanta()
            {
                Denumire = value.Denumire,
                DataInceput = value.DataInceput,
                DataSfarsit = value.DataSfarsit,
                Oras = value.Oras,
                Tara = value.Tara
            };

            return IVacantaRepository.Create(model);
        }

        // PUT api/<VacantaController>/5
        [HttpPut("{id}")]
        public Vacanta Put(int id, VacantaDTO value)
        {
            Vacanta model = IVacantaRepository.Get(id);
            DateTime? dt = null;

            if (value.Denumire != null)
            {
                model.Denumire = value.Denumire;
            }

            if (value.DataInceput != dt)
            {
                model.DataInceput = value.DataInceput;
            }

            if (value.DataSfarsit != dt)
            {
                model.DataSfarsit = value.DataSfarsit;
            }

            if (value.Oras != null)
            {
                model.Oras = value.Oras;
            }

            if (value.Tara != null)
            {
                model.Tara = value.Tara;
            }

            return IVacantaRepository.Update(model);
        }

        // DELETE api/<VacantaController>/5
        [HttpDelete("{id}")]
        public Vacanta Delete(int id)
        {
            Vacanta vacanta = IVacantaRepository.Get(id);
            return IVacantaRepository.Delete(vacanta);
        }
    }
}
