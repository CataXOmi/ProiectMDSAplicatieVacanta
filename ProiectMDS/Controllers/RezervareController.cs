using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.UtilizatorRepository;
using ProiectMDS.Repositories.VacantaRepository;
using ProiectMDS.Repositories.RezervareRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervareController : ControllerBase
    {
        public IRezervareRepository IRezervareRepository { get; set; }
        public IVacantaRepository IVacantaRepository { get; set; }
        public IUtilizatorRepository IUtilizatorRepository { get; set; }

        public RezervareController(IRezervareRepository rezervareRepository, IVacantaRepository vacantaRepository, IUtilizatorRepository utilizatorRepository)
        {
            IRezervareRepository = rezervareRepository;
            IUtilizatorRepository = utilizatorRepository;
            IVacantaRepository = vacantaRepository;
        }
        
        // GET: api/<RezervareController>
        [HttpGet]
        public ActionResult<IEnumerable<Rezervare>> Get()
        {
            return IRezervareRepository.GetAll();
        }

        // GET api/<RezervareController>/5
        [HttpGet("{id}")]
        public RezervareDetailsDTO Get(int id)
        {
            Rezervare rezervare = IRezervareRepository.Get(id);
            Vacanta vacanta = IVacantaRepository.Get(id);
            Utilizator utilizator = IUtilizatorRepository.Get(id);

            RezervareDetailsDTO myRezervare = new RezervareDetailsDTO()
            {
                DataRezervare = rezervare.DataRezervare,
                Review = rezervare.Review,
                Rating = rezervare.Rating
            };

            IEnumerable<Rezervare> MyRezervariVacante = IRezervareRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            if (MyRezervariVacante != null)
            {
                List<string> VacantaDenumireList = new List<string>();
                foreach (Rezervare myRezervareVacanta in MyRezervariVacante)
                {
                    Vacanta myVacanta = IVacantaRepository.GetAll().SingleOrDefault(x => x.ID == myRezervareVacanta.VacantaID);
                    VacantaDenumireList.Add(myVacanta.Denumire);
                }
                myRezervare.VacantaDenumire = VacantaDenumireList;
            }

            IEnumerable<Rezervare> MyRezervariUtilizatori = IRezervareRepository.GetAll().Where(x => x.UtilizatorID == utilizator.ID);
            if (MyRezervariUtilizatori != null)
            {
                List<string> UtilizatorUsernameList = new List<string>();
                foreach (Rezervare myRezervareUtilizator in MyRezervariUtilizatori)
                {
                    Utilizator myUser = IUtilizatorRepository.GetAll().SingleOrDefault(x => x.ID == myRezervareUtilizator.UtilizatorID);
                    UtilizatorUsernameList.Add(myUser.Username);
                }
                myRezervare.UtilizatorUsername = UtilizatorUsernameList;
            }

            return myRezervare;
        }

        // POST api/<RezervareController>
        [HttpPost]
        public Rezervare Post(RezervareDTO value)
        {
            Rezervare model = new Rezervare()
            {
                DataRezervare = value.DataRezervare,
                Rating = value.Rating,
                Review = value.Review,
                UtilizatorID = value.UtilizatorID,
                VacantaID = value.VacantaID
            };
            return IRezervareRepository.Create(model);

        }

        // PUT api/<RezervareController>/5
        [HttpPut("{id}")]
        public Rezervare Put(int id, RezervareDTO value)
        {
            Rezervare model = IRezervareRepository.Get(id);
            if (value.DataRezervare != null)
            {
                model.DataRezervare = value.DataRezervare;
            }

            if (value.Rating != 0)
            {
                model.Rating = value.Rating;
            }

            if (value.Review != null)
            {
                model.Review = value.Review;
            }

            if (value.VacantaID != null)
            {
                model.VacantaID = value.VacantaID;
            }

            if (value.UtilizatorID != null)
            {
                model.UtilizatorID = value.UtilizatorID;
            }
            return IRezervareRepository.Update(model);
        }

        // DELETE api/<RezervareController>/5
        [HttpDelete("{id}")]
        public Rezervare Delete(int id)
        {
            Rezervare rezervare = IRezervareRepository.Get(id);
            return IRezervareRepository.Delete(rezervare);
        }
    }
}
