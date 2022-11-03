using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using BL;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController1 : ControllerBase
    {

        IComplaintBL complaintBL;

        public ComplaintController1(IComplaintBL complaintBL)
        {
            this.complaintBL = complaintBL;
        }
        // GET: api/<ComplaintController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ComplaintController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComplaintController1>
        [HttpPost]
        public async Task Post([FromBody] Complaints complaint)
        {
            await complaintBL.sendComplaint(complaint);
        }

        // PUT api/<ComplaintController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComplaintController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
