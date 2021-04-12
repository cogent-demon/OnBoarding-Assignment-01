using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using testAppication6.Models;
//using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
//using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
//using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
//using RouteAttribute = System.Web.Http.RouteAttribute;

namespace testAppication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AccountController(IConfiguration configuration)
        {
            _config = configuration;

        }

        //get method using sql queries
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                     select Name, Bill_ID, Ship_ID, Acc_Address1,Acc_Address2, Acc_City, Bill_Address1,Bill_Address2, 
                      Ship_Address1,Ship_Address2,Email,Email_Sub,Acc_District, Phone_Code, Phone_Number,
                        Start_Date, Request FROM dbo.Account a, dbo.Billing b, dbo.Shippng s  
                        where a.Acc_ID = b.Acc_ID and   
                    a.Acc_ID = s.Acc_ID ";
            DataTable table = new DataTable();
            string sqlDataSourse = _config.GetConnectionString("TestDB");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSourse))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {
                    myreader = myCommand.ExecuteReader();
                    table.Load(myreader); ;

                    myreader.Close();
                    mycon.Close();

                }
            }

            return new JsonResult(table);
        }
       
    }


}
