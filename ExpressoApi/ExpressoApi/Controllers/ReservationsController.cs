using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpressoApi.Data;
using ExpressoApi.Models;

namespace ExpressoApi.Controllers
{
    public class ReservationsController : ApiController
    {
        ExpressoDbContext expressoDbContext = new ExpressoDbContext();

        public IHttpActionResult Post(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            expressoDbContext.Reservations.Add(reservation);
            expressoDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
