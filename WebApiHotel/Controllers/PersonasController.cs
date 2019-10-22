using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHotel.Models;

namespace WebApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly HotelContext _context;
        public PersonasController(HotelContext Contexto)
        {
            _context = Contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonaItems()
        {
            return await _context.Persona.ToListAsync();
        }
    }
}