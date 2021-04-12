using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAppication6.Models;

namespace testAppication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippngsController : ControllerBase
    {
        private readonly TestDB1Context _context;
        private readonly AccountsController accountsController;
        private readonly TestDB1Context testDB1Context;
        public ShippngsController(TestDB1Context context)
        {
            _context = context;
        }

        // GET: api/Shippngs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shippng>>> GetShippngs()
        {
            return await _context.Shippngs.ToListAsync();
        }

        // GET: api/Shippngs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shippng>> GetShippng(int id)
        {
            var shippng = await _context.Shippngs.FindAsync(id);

            if (shippng == null)
            {
                return NotFound();
            }

            return shippng;
        }

        // POST: api/Shippngs
         [HttpPost]
        public async Task<ActionResult<Shippng>> PostShippng(Shippng shippng)
        {
            AccountsController accres = new AccountsController(testDB1Context);
            shippng.AccId = accres.getAccountResponseID();

            _context.Shippngs.Add(shippng);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShippngExists(shippng.ShipId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShippng", new { id = shippng.ShipId }, shippng);
        }

        private bool ShippngExists(int id)
        {
            return _context.Shippngs.Any(e => e.ShipId == id);
        }
    }
}
