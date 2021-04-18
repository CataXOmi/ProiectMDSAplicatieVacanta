using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.RezervareCazareRepository;
using ProiectMDS.Repositories.CazareRepository;
using ProiectMDS.Repositories.VacantaRepository;




namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervareCazareController : ControllerBase
    {
        public IRezervareCazareRepository IRezervareCazareRepository { get; set; }
        public IVacantaRepository IVacantaRepository { get; set; }
        public ICazareRepository ICazareRepository { get; set; }

        public RezervareCazareController(IRezervareCazareRepository rezervareCazareRepository, ICazareRepository cazareRepository, IVacantaRepository vacantaRepository)
        {
            ICazareRepository = cazareRepository;
            IRezervareCazareRepository = rezervareCazareRepository;
            IVacantaRepository = vacantaRepository;
        }

        // GET: api/<RezervareCazareController>
        [HttpGet]
        public ActionResult<IEnumerable<RezervareCazare>> Get()
        {
            return IRezervareCazareRepository.GetAll();
        }

        // GET api/<RezervareCazareController>/5
        [HttpGet("{id}")]
        public RezervareCazareDetailsDTO Get(int id)
        {
            RezervareCazare rezervareCazare = IRezervareCazareRepository.Get(id);
            Vacanta vacanta = IVacantaRepository.Get(rezervareCazare.VacantaID);
            Cazare cazare = ICazareRepository.Get(rezervareCazare.CazareID);
            RezervareCazareDetailsDTO myRezervareCazare = new RezervareCazareDetailsDTO();

            if (rezervareCazare != null)
            {
                myRezervareCazare.CodRezervare = rezervareCazare.CodRezervare;
                myRezervareCazare.DataSosire = rezervareCazare.DataSosire;
                myRezervareCazare.DataPlecare = rezervareCazare.DataPlecare;
                myRezervareCazare.CazareNume = cazare.Nume;
                myRezervareCazare.VacantaDenumire = vacanta.Denumire;
            };

            return myRezervareCazare;
        }

        // POST api/<RezervareCazareController>
        [HttpPost]
        public RezervareCazare Post(RezervareCazareDTO value)
        {
            RezervareCazare model = new RezervareCazare()
            {
                CodRezervare = value.CodRezervare,
                DataPlecare = value.DataPlecare,
                DataSosire = value.DataSosire,
                CazareID = value.CazareID,
                VacantaID = value.VacantaID
            };

            return IRezervareCazareRepository.Create(model);
        }

        // PUT api/<RezervareCazareController>/5
        [HttpPut("{id}")]
        public RezervareCazare Put(int id, RezervareCazareDTO value)
        {
            RezervareCazare model = IRezervareCazareRepository.Get(id);
            DateTime? dt = null;

            if (value.CodRezervare != null)
            {
                model.CodRezervare = value.CodRezervare;
            }

            if (value.CazareID != 0)
            {
                model.CazareID = value.CazareID;
            }

            if (value.DataPlecare != dt)
            {
                model.DataPlecare = value.DataPlecare;
            }

            if (value.DataSosire != dt)
            {
                model.DataSosire = value.DataSosire;
            }

            if (value.VacantaID != 0)
            {
                model.VacantaID = value.VacantaID;
            }

            return IRezervareCazareRepository.Update(model);
        }

        // DELETE api/<RezervareCazareController>/5
        [HttpDelete("{id}")]
        public RezervareCazare Delete(int id)
        {
            RezervareCazare rezervareCazare = IRezervareCazareRepository.Get(id);
            return IRezervareCazareRepository.Delete(rezervareCazare);
        }
    }
}
