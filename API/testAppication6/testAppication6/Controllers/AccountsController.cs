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
//API Controller for account table
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public static int accountID;
        private readonly TestDB1Context testDBobj;

        public AccountsController(TestDB1Context context)
        {
            testDBobj = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var products = testDBobj.Accounts
                .Include(p => p.Billings)
                .Include(q => q.Shippngs)
                .ToList();
            return products;
            //  return await _context.Accounts.ToListAsync();
        //    return await contact.ToListAsync();

        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await testDBobj.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        // Post: api/Accounts
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            testDBobj.Accounts.Add(account);
            try
            {
              
                await testDBobj.SaveChangesAsync();

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

            var act = CreatedAtAction("GetAccount", new { id = account.AccId }, account);
            accountID = account.AccId;
            return act;
        }



        private bool AccountExists(int id)
        {
            return testDBobj.Accounts.Any(e => e.AccId == id);
        }

        public int getAccountResponseID()   //return ID forien key of billing and shipping
        {
            return accountID;
        
        }
    }
}
