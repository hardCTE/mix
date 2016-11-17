using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DataController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public Paging<Address> GetList()
        {
            #region Data

            var list = new List<Address>
            {
                new Address
                {
                    Name = "Lucy",
                    Position = "U.K",
                    Office = "SOHO",
                    Extn = "Street No. 1",
                    StartDate = DateTime.Now.AddDays(-123),
                    Salary = 123123.12M,
                },
                new Address
                {
                    Name = "Lucy123",
                    Position = "U.K",
                    Office = "SOHO",
                    Extn = "Street No. 2",
                    StartDate = DateTime.Now.AddDays(-123),
                    Salary = 123123.12M,
                },
                new Address
                {
                    Name = "Lucy111",
                    Position = "U.K",
                    Office = "SOHO",
                    Extn = "Street No. 3",
                    StartDate = DateTime.Now.AddDays(-123),
                    Salary = 123123.12M,
                },
                new Address
                {
                    Name = "Lucy2223",
                    Position = "U.K",
                    Office = "SOHO",
                    Extn = "Street No. 4",
                    StartDate = DateTime.Now.AddDays(-123),
                    Salary = 123123.12M,
                },
                new Address
                {
                    Name = "Lucy5353",
                    Position = "U.K",
                    Office = "SOHO",
                    Extn = "Street No. 5",
                    StartDate = DateTime.Now.AddDays(-123),
                    Salary = 123123.12M,
                },
                new Address
                {
                    Name = "Lucy67546",
                    Position = "U.K",
                    Office = "SOHO",
                    Extn = "Street No. 132",
                    StartDate = DateTime.Now.AddDays(-123),
                    Salary = 123123.12M,
                },
                new Address
                {
                    Name = "Lucy85656",
                    Position = "U.K",
                    Office = "SOHO",
                    Extn = "Street No. 10",
                    StartDate = DateTime.Now.AddDays(-123),
                    Salary = 123123.12M,
                }
            };

            #endregion

            return new Paging<Address>
            {
                Draw = (Int64)(DateTime.Now - new DateTime(2016, 1, 1)).TotalSeconds,
                RecordsTotal = 50,
                RecordsFiltered = 50,
                Data = list.Take(4).ToList()
            };
        }
    }

    public class Paging<T>
    {
        public Int64 Draw { get; set; }
        public Int64 RecordsTotal { get; set; }
        public Int64 RecordsFiltered { get; set; }
        public IList<T> Data { get; set; }
    }

    public class Address
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public string Extn { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
    }
}
