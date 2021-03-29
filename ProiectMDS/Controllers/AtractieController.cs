using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.AtractieRepository;




namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtractieController : ControllerBase
    {
        public IAtractieRepository IAtractieRepository { get; set; }
        public AtractieController(IAtractieRepository repository)
        {
            IAtractieRepository = repository;
        }

        // GET: api/<AtractieController>
        [HttpGet]
        public ActionResult<IEnumerable<Atractie>> Get()
        {
            return IAtractieRepository.GetAll();
        }

        // GET api/<AtractieController>/5
        [HttpGet("{id}")]
        public ActionResult<Atractie> Get(int id)
        {
            return IAtractieRepository.Get(id);
        }

        // POST api/<AtractieController>
        [HttpPost]
        public Atractie Post(AtractieDTO value)
        {
            Atractie model = new Atractie()
            {
                Denumire = value.Denumire,
                OraDeschidere = value.OraDeschidere,
                OraInchidere = value.OraInchidere,
                Pret = value.Pret,
                Oras = value.Oras, 
                Adresa = value.Adresa
            };
            return IAtractieRepository.Create(model);
        }

        // PUT api/<AtractieController>/5
        [HttpPut("{id}")]
        public Atractie Put(int id, AtractieDTO value)
        {
            Atractie model = IAtractieRepository.Get(id);

            if (value.Denumire != null)
            {
                model.Denumire = value.Denumire;
            }

            if (value.OraDeschidere != TimeSpan.Zero)
            {
                model.OraDeschidere = value.OraDeschidere;
            }

            if (value.OraInchidere != TimeSpan.Zero)
            {
                model.OraInchidere = value.OraInchidere;
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

            return IAtractieRepository.Update(model);
        }

        // DELETE api/<AtractieController>/5
        [HttpDelete("{id}")]
        public Atractie Delete(int id)
        {
            Atractie atractie = IAtractieRepository.Get(id);
            return IAtractieRepository.Delete(atractie);
        }
    }
}
