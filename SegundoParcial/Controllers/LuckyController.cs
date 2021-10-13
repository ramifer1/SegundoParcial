using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundoParcial.Data;
using SegundoParcial.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuckyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LuckyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cancions
        [HttpGet]
        public async Task<ActionResult<Fortuna>> GetFortuna()
        { //obetener una cancion de manera random Cancion modelo

            var list = await _context.Fortuna.ToListAsync(); //Cancion Modelo sacar la lista

            var max = list.Count;
            int index = new Random().Next(0, max);

            var cancion = list[index]; //busca la cancion

            if (cancion == null)
            {
                return NoContent();
            }

            return cancion;
        }
    }
}

