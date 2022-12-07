using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using HTML5_CSS_Course_Backend_Models;
using HTML5_CSS_Course_Backend_Logic;
using System.ComponentModel.DataAnnotations;

namespace HTML5_CSS_Course_Backend_Endpoint
{
    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        ITableLogic tableLogic;
        IReservationLogic reservationLogic;

        public AdminController(ITableLogic tableLogic, IReservationLogic reservationLogic)
        {
            this.tableLogic = tableLogic;
            this.reservationLogic = reservationLogic;
        }
        [HttpPut("modify")]
        public IActionResult Modify(Table table)
        {
            try
            {
                tableLogic.Update(table);
                return Ok(tableLogic.Read(table.id)!);
            }
            catch (Exception e)
            {
                return ControllerHelper.GetStatusCode(e, this);
            }
        }
        [HttpPut("enable/{name}")]
        public IActionResult Enable(string name)
        {
            try
            { 
                tableLogic.Enable(name);
                return Ok(tableLogic.GetByName(name)!);
            }
            catch (Exception e)
            {
                return ControllerHelper.GetStatusCode(e, this);
            }
        }
        [HttpPut("disable/{name}")]
        public IActionResult Disable(string name)
        {
            try
            {    
                tableLogic.Disable(name);
                return Ok(tableLogic.GetByName(name)!);
            }
            catch (Exception e)
            {
                return ControllerHelper.GetStatusCode(e, this);
            }
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] Table value)
        {
            if (value.name == null)
            {
                return BadRequest();
            }
            try
            {
                value.id = 0;
                tableLogic.Create(value);
                return Ok(tableLogic.GetByName(value.name)!);
            }
            catch (Exception e)
            {
                return ControllerHelper.GetStatusCode(e, this);
            }
        }
        [HttpGet("getbystate/{state}")]
        public IActionResult GetByState(string state)
        {
            bool b;
            if (bool.TryParse(state.ToLower(), out b))
            {
                try
                {
                    return Ok(tableLogic.GetByState(b));
                }
                catch (Exception e)
                {
                    return ControllerHelper.GetStatusCode(e, this);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("getbyname/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return Ok(tableLogic.GetByName(name));
            }
            catch (Exception e)
            {
                return ControllerHelper.GetStatusCode(e, this);
            }
        }
        [HttpDelete("delete/{name}")]
        public void Delete(string name)
        {
            tableLogic.DeleteByName(name);
        }
    }
}