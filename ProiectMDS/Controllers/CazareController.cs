using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.CazareRepository;
using ProiectMDS.Repositories.PachetRepository;
using ProiectMDS.Repositories.FacilitateRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CazareController : ControllerBase
    {
        public ICazareRepository ICazareRepository { get; set; }
        public IPachetRepository IPachetRepository { get; set; }
        public IFacilitateRepository IFacilitateRepository { get; set; }
        public CazareController(ICazareRepository repository, IPachetRepository pachetRepository, IFacilitateRepository facilitateRepository)
        {
            ICazareRepository = repository;
            IPachetRepository = pachetRepository;
            IFacilitateRepository = facilitateRepository;
        }

        // GET: api/<CazareController>
        [HttpGet]
        public ActionResult<IEnumerable<Cazare>> Get()
        {
            return ICazareRepository.GetAll();
        }

        // GET api/<CazareController>/5
        [HttpGet("{id}")]
        public CazareDTO Get(int id)
        {
            Cazare cazare = ICazareRepository.Get(id);
            //Pachet pachet = IPachetRepository.Get(cazare.ID);
            CazareDTO myCazare = new CazareDTO();

            if (myCazare != null)
            {
                myCazare.Adresa = cazare.Adresa;
                myCazare.Nume = cazare.Nume;
                myCazare.Oras = cazare.Oras;
                myCazare.Pret = cazare.Pret;
                myCazare.TipCazare = cazare.TipCazare;
            }

            IEnumerable<Pachet> myPachete = IPachetRepository.GetAll().Where(x => x.CazareID == cazare.ID);
            List<int> ListaFacilitati = new List<int>();
            if (myPachete != null)
            {
                foreach (Pachet mypack in myPachete)
                {
                    ListaFacilitati.Add(mypack.FacilitateID);
                }
                //myUtilizator.FotografieID = ListaFotografii;
            }


            IEnumerable<Pachet> myPacks = IPachetRepository.GetAll().Where(x => x.CazareID == cazare.ID);
            List<string> ListaUtilities = new List<string>();
            if (myPacks != null)
            {
                foreach (int facilitateID in ListaFacilitati)
                {
                    Facilitate facilitate = IFacilitateRepository.Get(facilitateID);
                    ListaUtilities.Add(facilitate.Denumire);
                }
            }
            myCazare.ListaFacilitati = ListaUtilities.ToList();

            return myCazare;
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
