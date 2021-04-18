using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.PachetRepository;
using ProiectMDS.Repositories.FacilitateRepository;
using ProiectMDS.Repositories.CazareRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PachetController : ControllerBase
    {
        public IPachetRepository IPachetRepository { get; set; }
        public IFacilitateRepository IFacilitateRepository { get; set; }
        public ICazareRepository ICazareRepository { get; set; }

        public PachetController(IPachetRepository pachetRepository, ICazareRepository cazareRepository, IFacilitateRepository facilitateRepository)
        {
            IPachetRepository = pachetRepository;
            IFacilitateRepository = facilitateRepository;
            ICazareRepository = cazareRepository;
        }
        
        // GET: api/<PachetController>
        [HttpGet]
        public ActionResult<IEnumerable<Pachet>> Get()
        {
            return IPachetRepository.GetAll();
        }

        // GET api/<PachetController>/5
        [HttpGet("{id}")]
        public PachetDetailsDTO Get(int id)
        {
            Pachet pachet = IPachetRepository.Get(id);
            Cazare cazare = ICazareRepository.Get(pachet.CazareID);
            Facilitate facilitate = IFacilitateRepository.Get(pachet.FacilitateID);

            PachetDetailsDTO myPachet = new PachetDetailsDTO()
            {
                CazareNume = cazare.Nume,
                FacilitateDenumire = facilitate.Denumire
            };

            return myPachet;
        }

        // POST api/<PachetController>
        [HttpPost]
        public Pachet Post(PachetDTO value)
        {
            Pachet model = new Pachet()
            {
                CazareID = value.CazareID,
                FacilitateID = value.FacilitateID
            };

            return IPachetRepository.Create(model);
        }

        // PUT api/<PachetController>/5
        [HttpPut("{id}")]
        public Pachet Put(int id, PachetDTO value)
        {
            Pachet model = IPachetRepository.Get(id);
            if (value.CazareID != 0)
            {
                model.CazareID = value.CazareID;
            }

            if (value.FacilitateID != 0)
            {
                model.FacilitateID = value.FacilitateID;
            }

            return IPachetRepository.Update(model);
        }

        // DELETE api/<PachetController>/5
        [HttpDelete("{id}")]
        public Pachet Delete(int id)
        {
            Pachet pachet = IPachetRepository.Get(id);
            return IPachetRepository.Delete(pachet);
        }
    }
}
