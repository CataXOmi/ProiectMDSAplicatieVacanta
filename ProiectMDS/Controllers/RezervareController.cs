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
using ProiectMDS.Repositories.RezervareCazareRepository;
using ProiectMDS.Repositories.CazareRepository;
using ProiectMDS.Repositories.TichetMasaRepository;
using ProiectMDS.Repositories.RestaurantRepository;
using ProiectMDS.Repositories.BiletRepository;
using ProiectMDS.Repositories.AtractieRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervareController : ControllerBase
    {
        public IRezervareRepository IRezervareRepository { get; set; }
        public IVacantaRepository IVacantaRepository { get; set; }
        public IUtilizatorRepository IUtilizatorRepository { get; set; }
        public IRezervareCazareRepository IRezervareCazareRepository { get; set; }
        public ICazareRepository ICazareRepository { get; set; }
        public ITichetMasaRepository ITichetMasaRepository { get; set; }
        public IRestaurantRepository IRestaurantRepository { get; set; }
        public IBiletRepository IBiletRepository { get; set; }
        public IAtractieRepository IAtractieRepository { get; set; }


        public RezervareController(IRezervareRepository rezervareRepository, IVacantaRepository vacantaRepository, IUtilizatorRepository utilizatorRepository,
            IRezervareCazareRepository rezervareCazareRepository, ICazareRepository cazareRepository, ITichetMasaRepository tichetMasaRepository,
            IRestaurantRepository restaurantRepository, IBiletRepository biletRepository, IAtractieRepository atractieRepository)
        {
            IRezervareRepository = rezervareRepository;
            IUtilizatorRepository = utilizatorRepository;
            IVacantaRepository = vacantaRepository;
            IRezervareCazareRepository = rezervareCazareRepository;
            ICazareRepository = cazareRepository;
            ITichetMasaRepository = tichetMasaRepository;
            IRestaurantRepository = restaurantRepository;
            IBiletRepository = biletRepository;
            IAtractieRepository = atractieRepository;
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
            Vacanta vacanta = IVacantaRepository.Get(rezervare.VacantaID);
            Utilizator utilizator = IUtilizatorRepository.Get(rezervare.UtilizatorID);
            //RezervareCazare rezervareCazare = IRezervareCazareRepository.Get(vacanta.ID);
            //Cazare cazare = ICazareRepository.Get(rezervareCazare.CazareID);
            //TichetMasa tichetMasa = ITichetMasaRepository.Get(vacanta.ID);
            //Restaurant restaurant = IRestaurantRepository.Get(tichetMasa.RestaurantID);
            //Bilet bilet = IBiletRepository.Get(vacanta.ID);
            //Atractie atractie = IAtractieRepository.Get(bilet.AtractieID);


            RezervareDetailsDTO myRezervare = new RezervareDetailsDTO();
            if (rezervare != null)
            {
                myRezervare.DataRezervare = rezervare.DataRezervare;
                myRezervare.Review = rezervare.Review;
                myRezervare.Rating = rezervare.Rating;
                myRezervare.UtilizatorUsername = utilizator.Username;
                myRezervare.VacantaDenumire = vacanta.Denumire;
                myRezervare.VacantaDataInceput = vacanta.DataInceput;
                myRezervare.VacantaDataSfarsit = vacanta.DataSfarsit;
            }

            IEnumerable<RezervareCazare> myRezervariCazari = IRezervareCazareRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            List<int> ListaRezervariCazari = new List<int>();
            if (myRezervariCazari != null)
            {
                foreach (RezervareCazare myRezCazare in myRezervariCazari)
                {
                    ListaRezervariCazari.Add(myRezCazare.CazareID);
                }
                //myUtilizator.FotografieID = ListaFotografii;
            }


            IEnumerable<Rezervare> myRezervari = IRezervareRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            List<string> ListaRezervari = new List<string>();
            if (myRezervari != null)
            {
                foreach (int cazareID in ListaRezervariCazari)
                {
                    Cazare cazare = ICazareRepository.Get(cazareID);
                    ListaRezervari.Add(cazare.Nume);
                }
            }
            myRezervare.ListaCazari = ListaRezervari.ToList();


            IEnumerable<TichetMasa> myTicheteMasa = ITichetMasaRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            List<int> ListaTicheteMasa = new List<int>();
            if (myTicheteMasa != null)
            {
                foreach (TichetMasa myTicMasa in myTicheteMasa)
                {
                    ListaTicheteMasa.Add(myTicMasa.RestaurantID);
                }
                //myUtilizator.FotografieID = ListaFotografii;
            }

            IEnumerable<Rezervare> myRezervari2 = IRezervareRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            List<string> ListaRezervari2 = new List<string>();
            if (myRezervari2 != null)
            {
                foreach (int restaurantID in ListaTicheteMasa)
                {
                    Restaurant restaurant = IRestaurantRepository.Get(restaurantID);
                    ListaRezervari2.Add(restaurant.Nume);
                }
            }
            myRezervare.ListaRestaurante = ListaRezervari2.ToList();

            IEnumerable<Bilet> myBilete = IBiletRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            List<int> ListaBilete = new List<int>();
            if (myBilete != null)
            {
                foreach (Bilet mybil in myBilete)
                {
                    ListaBilete.Add(mybil.AtractieID);
                }
                //myUtilizator.FotografieID = ListaFotografii;
            }

            IEnumerable<Rezervare> myRezervari3 = IRezervareRepository.GetAll().Where(x => x.VacantaID == vacanta.ID);
            List<string> ListaRezervari3 = new List<string>();
            if (myRezervari3 != null)
            {
                foreach (int atractieID in ListaBilete)
                {
                    Atractie atractie = IAtractieRepository.Get(atractieID);
                    ListaRezervari3.Add(atractie.Denumire);
                }
            }
            myRezervare.ListaAtractii = ListaRezervari3.ToList();

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

            if (value.VacantaID != 0)
            {
                model.VacantaID = value.VacantaID;
            }

            if (value.UtilizatorID != 0)
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
