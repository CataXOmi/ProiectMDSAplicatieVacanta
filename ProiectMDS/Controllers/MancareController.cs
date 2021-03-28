using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.DTOs;
using ProiectMDS.Repositories.MancareRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MancareController : ControllerBase
    {
        public IMancareRepository IMancareRepository { get; set; }
        public MancareController(IMancareRepository repository)
        {
            IMancareRepository = repository;
        }

        // GET: api/<MancareController>
        [HttpGet]
        public ActionResult<IEnumerable<Mancare>> Get()
        {
            return IMancareRepository.GetAll();
        }

        // GET api/<MancareController>/5
        [HttpGet("{id}")]
        public ActionResult<Mancare> Get(int id)
        {
            return IMancareRepository.Get(id);
        }

        // POST api/<MancareController>
        [HttpPost]
        public Mancare Post(MancareDTO value)
        {
            Mancare model = new Mancare()
            {
                Denumire = value.Denumire
            };
            return IMancareRepository.Create(model);
        }

        // PUT api/<MancareController>/5
        [HttpPut("{id}")]
        public Mancare Put(int id, MancareDTO value)
        {
            Mancare model = IMancareRepository.Get(id);

            if (value.Denumire != null)
            {
                model.Denumire = value.Denumire;
            }

            return IMancareRepository.Update(model);
        }

        // DELETE api/<MancareController>/5
        [HttpDelete("{id}")]
        public Mancare Delete(int id)
        {
            Mancare mancare = IMancareRepository.Get(id);
            return IMancareRepository.Delete(mancare);
        }
    }
}
