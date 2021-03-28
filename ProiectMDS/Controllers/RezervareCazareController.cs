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
            Vacanta vacanta = IVacantaRepository.Get(id);
            Cazare cazare = ICazareRepository.Get(id);

            RezervareCazareDetailsDTO myRezervareCazare = new RezervareCazareDetailsDTO()
            {
                CodRezervare = rezervareCazare.CodRezervare
            };

            IEnumerable<RezervareCazare> myRezervareCazariCazare = IRezervareCazareRepository.GetAll().Where(x => x.CazareID == cazare.ID);
            if (myRezervareCazariCazare != null)
            {
                List<string> CazareNumeList = new List<string>();
                foreach (RezervareCazare myRezervareCazareCazare in myRezervareCazariCazare)
                {
                    Cazare myCazare = ICazareRepository.GetAll().SingleOrDefault(x => x.ID == myRezervareCazareCazare.VacantaID);
                    CazareNumeList.Add(myCazare.Nume);
                }
                myRezervareCazare.CazareNume = CazareNumeList;
            }

            IEnumerable<RezervareCazare> myRezervareCazariVacanta = IRezervareCazareRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            if (myRezervareCazariVacanta != null)
            {
                List<string> VacantaDenumireList = new List<string>();
                foreach (RezervareCazare myRezervareCazareVacanta in myRezervareCazariCazare)
                {
                    Vacanta myVacanta = IVacantaRepository.GetAll().SingleOrDefault(x => x.ID == myRezervareCazareVacanta.VacantaID);
                    VacantaDenumireList.Add(myVacanta.Denumire);
                }
                myRezervareCazare.VacantaDenumire = VacantaDenumireList;
            }

            return myRezervareCazare;
        }

        // POST api/<RezervareCazareController>
        [HttpPost]
        public void Post(RezervareCazareDTO value)
        {
            RezervareCazare model = new RezervareCazare()
            {
                CodRezervare = value.CodRezervare
            };

            IRezervareCazareRepository.Create(model);
            for (int i = 0; i < value.VacantaID.Count; i++)
            {
                RezervareCazare rezervareCazareVacanta = new RezervareCazare()
                {
                    ID = model.ID,
                    VacantaID = value.VacantaID[i]
                };

                IRezervareCazareRepository.Create(rezervareCazareVacanta);
            }

            for (int i = 0; i < value.CazareID.Count; i++)
            {
                RezervareCazare rezervareCazareCazare = new RezervareCazare()
                {
                    ID = model.ID,
                    CazareID = value.CazareID[i]
                };

                IRezervareCazareRepository.Create(rezervareCazareCazare);
            }
        }

        // PUT api/<RezervareCazareController>/5
        [HttpPut("{id}")]
        public void Put(int id, RezervareCazareDTO value)
        {
            RezervareCazare model = IRezervareCazareRepository.Get(id);
            if (value.CodRezervare != null)
            {
                model.CodRezervare = value.CodRezervare;
            }

            IRezervareCazareRepository.Update(model);

            if (value.VacantaID != null)
            {
                IEnumerable<RezervareCazare> myRezervariCazariVacanta = IRezervareCazareRepository.GetAll().Where(x => x.VacantaID == id);
                foreach (RezervareCazare myRezervareCazareVacanta in myRezervariCazariVacanta)
                    IRezervareCazareRepository.Delete(myRezervareCazareVacanta);
                for (int i = 0; i < value.VacantaID.Count; i++)
                {
                    RezervareCazare RezervareCazareVacanta = new RezervareCazare()
                    {
                        ID = model.ID,
                        VacantaID = value.VacantaID[i]
                    };
                    IRezervareCazareRepository.Create(RezervareCazareVacanta);
                }
            }

            if (value.CazareID != null)
            {
                IEnumerable<RezervareCazare> myRezervariCazariCazare = IRezervareCazareRepository.GetAll().Where(x => x.CazareID == id);
                foreach (RezervareCazare myRezervareCazareCazare in myRezervariCazariCazare)
                    IRezervareCazareRepository.Delete(myRezervareCazareCazare);
                for (int i = 0; i < value.CazareID.Count; i++)
                {
                    RezervareCazare RezervareCazareCazare = new RezervareCazare()
                    {
                        ID = model.ID,
                        CazareID = value.CazareID[i]
                    };
                    IRezervareCazareRepository.Create(RezervareCazareCazare);
                }
            }
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
