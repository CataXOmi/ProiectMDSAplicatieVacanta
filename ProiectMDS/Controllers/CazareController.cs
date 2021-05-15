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
        public CazareDetailsDTO Get(int id)
        {
            Cazare cazare = ICazareRepository.Get(id);
            //Pachet pachet = IPachetRepository.Get(cazare.ID);
            CazareDetailsDTO myCazare = new CazareDetailsDTO();

            if (myCazare != null)
            {
                myCazare.Adresa = cazare.Adresa;
                myCazare.Nume = cazare.Nume;
                myCazare.Oras = cazare.Oras;
                myCazare.Pret = cazare.Pret;
                myCazare.TipCazare = cazare.TipCazare;
            }

            /*IEnumerable<Pachet> myPachete = IPachetRepository.GetAll().Where(x => x.CazareID == cazare.ID);
            List<int> ListaFacilitati = new List<int>();
            if (myPachete != null)
            {
                foreach (Pachet mypack in myPachete)
                {
                    ListaFacilitati.Add(mypack.FacilitateID);
                }
                //myUtilizator.FotografieID = ListaFotografii;
            }*/


            IEnumerable<Pachet> myPacks = IPachetRepository.GetAll().Where(x => x.CazareID == cazare.ID);
            List<string> ListaUtilities = new List<string>();
            if (myPacks != null)
            {
                foreach (Pachet mypachet in myPacks)
                {
                    Facilitate facilitate = IFacilitateRepository.GetAll().SingleOrDefault(x => x.ID == mypachet.FacilitateID);
                    ListaUtilities.Add(facilitate.Denumire);
                }
            }
            myCazare.ListaFacilitati = ListaUtilities;

            return myCazare;
        }

        // POST api/<CazareController>
        [HttpPost]
        public void Post(CazareDTO value)
        {
            Cazare model = new Cazare()
            {
                Nume = value.Nume,
                TipCazare = value.TipCazare,
                Pret = value.Pret,
                Oras = value.Oras,
                Adresa = value.Adresa
            };
            ICazareRepository.Create(model);

            for(int i = 0; i < value.ListaFacilitatiID.Count; i++)
            {
                Pachet pachet = new Pachet()
                {
                    CazareID = model.ID,
                    FacilitateID = value.ListaFacilitatiID[i]
                };
                IPachetRepository.Create(pachet);
            }
        }

        // PUT api/<CazareController>/5
        [HttpPut("{id}")]
        public void Put(int id, CazareDTO value)
        {
            Cazare model = ICazareRepository.Get(id);

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

            ICazareRepository.Update(model);

            if (value.ListaFacilitatiID != null)
            {
                IEnumerable<Pachet> myPachete = IPachetRepository.GetAll().Where(x => x.CazareID == id);
                foreach (Pachet myPachet in myPachete)
                    IPachetRepository.Delete(myPachet);
                for (int i = 0; i < value.ListaFacilitatiID.Count; i++)
                {
                    Pachet pachet = new Pachet()
                    {
                        CazareID = model.ID,
                        FacilitateID = value.ListaFacilitatiID[i]
                    };
                    IPachetRepository.Create(pachet);
                }
            }
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
