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
                    var tickets = context.Tickets.Where(x => x.Status == "Used").OrderByDescending(x => x.Date).Take(10).ToList();
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
                    
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("GetByCode/{code}")]
        public IActionResult GetByCode(int code)
        {
            try
            {
                using (var context = new project1databaseContext())
                {
                    var ticket = context.Tickets.Where(x => x.Code == code).FirstOrDefault();

                    if(ticket == null) return BadRequest(new { message = "El ticket no ha sido encontrado" });

                    if(ticket.Status == "Used") return BadRequest(new { message = "El ticket ya ha sido usado" });

                    return Ok(ticket);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}