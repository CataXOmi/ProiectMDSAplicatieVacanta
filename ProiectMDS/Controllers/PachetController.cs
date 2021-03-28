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
            Cazare cazare = ICazareRepository.Get(id);
            Facilitate facilitate = IFacilitateRepository.Get(id);

            PachetDetailsDTO myPachet = new PachetDetailsDTO()
            {

            };

            IEnumerable<Pachet> myPacheteCazare = IPachetRepository.GetAll().Where(x => x.CazareID == cazare.ID);
            if (myPacheteCazare != null)
            {
                List<string> CazareNumeList = new List<string>();
                foreach(Pachet myPachetCazare in myPacheteCazare)
                {
                    Cazare myCazare = ICazareRepository.GetAll().SingleOrDefault(x => x.ID == myPachetCazare.CazareID);
                    CazareNumeList.Add(myCazare.Nume);
                }
                myPachet.CazareNume = CazareNumeList;
            }

            IEnumerable<Pachet> MyPacheteFacilitate = IPachetRepository.GetAll().Where(x => x.FacilitateID == facilitate.ID);
            if (MyPacheteFacilitate != null)
            {
                List<string> FacilitateDenumireList = new List<string>();
                foreach (Pachet myPachetFacilitate in MyPacheteFacilitate)
                {
                    Facilitate myFacilitate = IFacilitateRepository.GetAll().SingleOrDefault(x => x.ID == myPachetFacilitate.FacilitateID);
                    FacilitateDenumireList.Add(myFacilitate.Denumire);
                }
                myPachet.FacilitateDenumire = FacilitateDenumireList;
            }

            return myPachet;
        }

        // POST api/<PachetController>
        [HttpPost]
        public void Post(PachetDTO value)
        {
            Pachet model = new Pachet()
            {

            };

            IPachetRepository.Create(model);
            for (int i = 0; i < value.CazareID.Count; i++)
            {
                Pachet PachetCazare = new Pachet()
                {
                    ID = model.ID,
                    CazareID = value.CazareID[i]
                };

                IPachetRepository.Create(PachetCazare);
            }

            for (int i = 0; i < value.FacilitateID.Count; i++)
            {
                Pachet PachetFacilitate = new Pachet()
                {
                    ID = model.ID,
                    FacilitateID = value.FacilitateID[i]
                };

                IPachetRepository.Create(PachetFacilitate);
            }
        }

        // PUT api/<PachetController>/5
        [HttpPut("{id}")]
        public void Put(int id, PachetDTO value)
        {
            Pachet model = IPachetRepository.Get(id);
            if (value.CazareID != null)
            {
                IEnumerable<Pachet> myPacheteCazare = IPachetRepository.GetAll().Where(x => x.CazareID == id);
                foreach (Pachet myPachetCazare in myPacheteCazare)
                    IPachetRepository.Delete(myPachetCazare);
                for (int i = 0; i < value.CazareID.Count; i++)
                {
                    Pachet PachetCazare = new Pachet()
                    {
                        ID = model.ID,
                        CazareID = value.CazareID[i]
                    };
                    IPachetRepository.Create(PachetCazare);
                }
            }

            if (value.FacilitateID != null)
            {
                IEnumerable<Pachet> myPacheteFacilitate = IPachetRepository.GetAll().Where(x => x.FacilitateID == id);
                foreach (Pachet myPachetFacilitate in myPacheteFacilitate)
                    IPachetRepository.Delete(myPachetFacilitate);
                for (int i = 0; i < value.FacilitateID.Count; i++)
                {
                    Pachet PachetFacilitate = new Pachet()
                    {
                        ID = model.ID,
                        FacilitateID = value.FacilitateID[i]
                    };
                    IPachetRepository.Create(PachetFacilitate);
                }
            }
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
