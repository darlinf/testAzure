using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (var context = new project1databaseContext())
                {
                    var tickets = context.Tickets.ToList();
                    return Ok(tickets);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
        [HttpGet("RedeemTicket/{code}")]
        public IActionResult ticket(int code)
        {
            try
            {
                using (var context = new project1databaseContext())
                {
                    var ticket = context.Tickets.Where(x => x.Code == code).FirstOrDefault();
                    ticket.Status = "Used";
                    ticket.Date = DateTime.Now;
                    context.Update(ticket);
                    context.SaveChanges();

                    var tickets = context.Tickets.Where(x => x.Status == "Used").OrderBy(x => x.Date).ToList();
                    
                    return Ok(tickets);
                }
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}