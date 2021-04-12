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
    public class AccountsController : ControllerBase
    {
        public static int accountID;
        private readonly TestDB1Context _context;

        public AccountsController(TestDB1Context context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var products = _context.Accounts
                .Include(p => p.Billings)
                .Include(p => p.Shippngs)
                .ToList();
            return products;
            //  return await _context.Accounts.ToListAsync();
        //    return await contact.ToListAsync();

        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }


        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            _context.Accounts.Add(account);
            try
            {
              
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                if (AccountExists(account.AccId))
                {
                   
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var ss = CreatedAtAction("GetAccount", new { id = account.AccId }, account);
            accountID = account.AccId;
            return ss;
        }



        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccId == id);
        }

        public int getAccountResponseID()
        {
            return accountID;
        
        }
    }
}
