using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.UtilizatorRepository;
using ProiectMDS.Repositories.FotografieRepository;
using ProiectMDS.Repositories.RezervareRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorController : ControllerBase
    {
        public IUtilizatorRepository IUtilizatorRepository { get; set; }
        public IFotografieRepository IFotografieRepository { get; set; }
        public IRezervareRepository IRezervareRepository { get; set; }

        public UtilizatorController(IUtilizatorRepository repository, IFotografieRepository fotografieRepository, IRezervareRepository rezervareRepository)
        {
            IUtilizatorRepository = repository;
            IFotografieRepository = fotografieRepository;
            IRezervareRepository = rezervareRepository;
        }
        
        // GET: api/<UtilizatorController>
        [HttpGet]
        public ActionResult<IEnumerable<Utilizator>> Get()
        {
            return IUtilizatorRepository.GetAll();
        }

        // GET api/<UtilizatorController>/5
        [HttpGet("{id}")]
        public UtilizatorDTO Get(int id)
        {
            Utilizator utilizator = IUtilizatorRepository.Get(id);
            UtilizatorDTO myUtilizator = new UtilizatorDTO()
            {
                Username = utilizator.Username,
                Nume = utilizator.Nume,
                Prenume = utilizator.Prenume,
                Email = utilizator.Email,
                Telefon = utilizator.Telefon,
                DataNasterii = utilizator.DataNasterii,
                Parola = utilizator.Parola
            };

            IEnumerable<Fotografie> myFotografii = IFotografieRepository.GetAll().Where(x => x.UtilizatorID == utilizator.ID);
            if (myFotografii != null)
            {
                List<int> ListaFotografii = new List<int>();
                foreach (Fotografie myFotografie in myFotografii)
                {
                    ListaFotografii.Add(myFotografie.ID);
                }
                myUtilizator.FotografieID = ListaFotografii;
            }

            IEnumerable<Rezervare> myRezervari = IRezervareRepository.GetAll().Where(x => x.UtilizatorID == utilizator.ID);
            if (myRezervari != null)
            {
                List<int> ListaRezervari = new List<int>();
                foreach (Rezervare rez in myRezervari)
                {
                    ListaRezervari.Add(rez.ID);
                }
                myUtilizator.RezervareID = ListaRezervari;
            }

            return myUtilizator;

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
                Telefon = value.Telefon,
                DataNasterii = value.DataNasterii,
                Parola = value.Parola
            };
            return IUtilizatorRepository.Create(model);
        }

        // PUT api/<UtilizatorController>/5
        [HttpPut("{id}")]
        public Utilizator Put(int id, UtilizatorDTO value)
        {
            Utilizator model = IUtilizatorRepository.Get(id);
            DateTime? dt = null;

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

            if (value.DataNasterii != dt)
            {
                model.DataNasterii = value.DataNasterii;
            }

            if (value.Parola != null)
            {
                model.Parola = value.Parola;
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
