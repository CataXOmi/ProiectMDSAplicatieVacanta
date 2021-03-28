using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.FacilitateRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitateController : ControllerBase
    {
        public IFacilitateRepository IFacilitateRepository { get; set; }
        public FacilitateController(IFacilitateRepository repository)
        {
            IFacilitateRepository = repository;
        }

        // GET: api/<FacilitateController>
        [HttpGet]
        public ActionResult<IEnumerable<Facilitate>> Get()
        {
            return IFacilitateRepository.GetAll();
        }

        // GET api/<FacilitateController>/5
        [HttpGet("{id}")]
        public ActionResult<Facilitate> Get(int id)
        {
            return IFacilitateRepository.Get(id);
        }

        // POST api/<FacilitateController>
        [HttpPost]
        public Facilitate Post(FacilitateDTO value)
        {
            Facilitate model = new Facilitate()
            {
                Denumire = value.Denumire
            };
            return IFacilitateRepository.Create(model);
        }

        // PUT api/<FacilitateController>/5
        [HttpPut("{id}")]
        public Facilitate Put(int id, FacilitateDTO value)
        {
            Facilitate model = IFacilitateRepository.Get(id);

            if (value.Denumire != null)
            {
                model.Denumire = value.Denumire;
            }

            return IFacilitateRepository.Update(model);
        }

        // DELETE api/<FacilitateController>/5
        [HttpDelete("{id}")]
        public Facilitate Delete(int id)
        {
            Facilitate facilitate = IFacilitateRepository.Get(id);
            return IFacilitateRepository.Delete(facilitate);
        }
    }
}
