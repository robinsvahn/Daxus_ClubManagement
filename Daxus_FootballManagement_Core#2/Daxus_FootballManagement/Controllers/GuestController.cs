using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model;
using Daxus_FootballManagement.DAL.Repositories.Implementations;
using Daxus_FootballManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Daxus_FootballManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/Guest")]
    public class GuestController : Controller
    {
        private readonly IGuestRepository _guestRepository;

        public GuestController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        // GET: api/Guest
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _guestRepository.GetAllAsync());
        }

        // GET: api/Guest/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var guest = await _guestRepository.GetByIdAsync(id);
            if (guest == null) return NotFound(id);

            return Ok(await _guestRepository.GetByIdAsync(id));
        }
        
        // POST: api/Guest
        [HttpPost]
        public async Task<IActionResult> Post(Guest guest)
        {
            if (guest == null) return BadRequest();
            await _guestRepository.AddAsync(guest);
            return Ok($"Guest {guest.Firstname} {guest.Lastname} was saved succesfully");
        }
        
        // PUT: api/Guest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Guest guest)
        {
            if (guest == null) return BadRequest();
            if (await _guestRepository.GetByIdAsync(id) == null) return BadRequest();

            await _guestRepository.UpdateAsync(guest);
            return Ok($"Guest {guest.Firstname} {guest.Lastname} was updated succesfully");
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var guest = await _guestRepository.GetByIdAsync(id);
            if (guest == null) return BadRequest();

            await _guestRepository.DeleteAsync(guest);
            return Ok($"Guest {guest.Firstname} {guest.Lastname} was deleted succesfully");
        }
    }
}
