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
//Billing table controler

    [Route("api/[controller]")]
    [ApiController]
    public class BillingsController : ControllerBase
    {
        private readonly TestDB1Context testDBobj;
        private readonly AccountsController accountsController;
        private readonly TestDB1Context testDB1Context;

        public BillingsController(TestDB1Context context)
        {
            testDBobj = context;
        }

        // GET: api/Billings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billing>>> GetBillings()
        {
            return await testDBobj.Billings.ToListAsync();
        }

        // GET: api/Billings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Billing>> GetBilling(int id)
        {
            var billing = await testDBobj.Billings.FindAsync(id);

            if (billing == null)
            {
                return NotFound();
            }

            return billing;
        }

        // POST: api/Billings
        [HttpPost]
        public async Task<ActionResult<Billing>> PostBilling(Billing billing)
        {
            AccountsController accres = new AccountsController(testDB1Context);
            billing.AccId = accres.getAccountResponseID();
            testDBobj.Billings.Add(billing);
            try
            {
                await testDBobj.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BillingExists(billing.BillId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBilling", new { id = billing.BillId }, billing);
        }

        private bool BillingExists(int id)         //Getting forien key 
        {
            return testDBobj.Billings.Any(e => e.BillId == id);
        }
    }
}
