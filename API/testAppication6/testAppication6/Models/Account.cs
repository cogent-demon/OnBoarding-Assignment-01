using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

#nullable disable

namespace testAppication6.Models
{
    public partial class Account
    {
        public Account()
        {
            Billings = new HashSet<Billing>();
              Shippngs = new HashSet<Shippng>();
        }


       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column( Order = 0)]
        public int AccId { get; set; }
        

        public string Name { get; set; }
        public string BName { get; set; }
        public int? PhoneCode { get; set; }
        public int? PhoneNumber { get; set; }
        public string AccAddress1 { get; set; }
        public string AccAddress2 { get; set; }
        public string AccCity { get; set; }
        public string AccDistrict { get; set; }
        public string Email { get; set; }

        internal Task<ActionResult<IEnumerable<Account>>> ToListAsync()
        {
            throw new NotImplementedException();
        }

        public DateTime StartDate { get; set; }

        public virtual ICollection<Billing> Billings { get; set; }
        public virtual ICollection<Shippng> Shippngs { get; set; }
    }
}
