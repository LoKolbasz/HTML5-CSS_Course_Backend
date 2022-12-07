using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Logic;

namespace HTML5_CSS_Course_Backend_Endpoint
{
    [ApiController]
    [Route("reservation")]
    public class ReservationController : ControllerBase
    {
        ITableLogic tableLogic;
        IReservationLogic reservationLogic;

        public ReservationController(ITableLogic tableLogic, IReservationLogic reservationLogic)
        {
            this.tableLogic = tableLogic;
            this.reservationLogic = reservationLogic;
        }
        [HttpGet("get")]
        public IActionResult Get(string start, string stop)
        {
            try
            {    
                DateTime startTime;
                DateTime stopTime;
                if (DateTime.TryParseExact(start, Reservation.dateTimeFormat, Reservation.formatProvider, Reservation.dateTimeStyles, out startTime) && DateTime.TryParseExact(stop, Reservation.dateTimeFormat, Reservation.formatProvider, Reservation.dateTimeStyles, out stopTime))
                {
                    return Ok(reservationLogic.Get(startTime, stopTime));
                }
                else return BadRequest();
            }
            catch (Exception e)
            {
                return ControllerHelper.GetStatusCode(e, this);
            }
        }

        [HttpGet("free")]
        public IActionResult Free(string start, string stop)
        {
            try
            {    
                DateTime startTime;
                DateTime stopTime;
                if (DateTime.TryParseExact(start, Reservation.dateTimeFormat, Reservation.formatProvider, Reservation.dateTimeStyles, out startTime) && DateTime.TryParseExact(stop, Reservation.dateTimeFormat, Reservation.formatProvider, Reservation.dateTimeStyles, out stopTime))
                {
                    return Ok(tableLogic.Free(startTime, stopTime));
                }
                else return BadRequest();
            }
            catch (Exception e)
            {
                return ControllerHelper.GetStatusCode(e, this);
            }
        }
        [HttpPost("save")]
        public IActionResult Save([FromBody] Reservation value)
        {
            try
            {
                reservationLogic.Create(value);
                return Ok();
            }
            catch (Exception e)
            {
                return ControllerHelper.GetStatusCode(e, this);
            }
        }
    }
}