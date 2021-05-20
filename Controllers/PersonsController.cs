using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTimeSheets.Domain.Interfaces;
using MyTimeSheets.Models.Dto;

namespace MyTimeSheets.Controllers
{  
    
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
          private readonly IPersonManager _personManager;

        public PersonsController (IPersonManager personManager )
        {
            _personManager = personManager ;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] int id)
        { 
           var result = _personManager.GetItem(id);
         return Ok(result);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        { 
          var result = _personManager.GetItems();
         return Ok(result);
        }

         [HttpPost("create")]
         public IActionResult Create([FromBody] PersonCreateRequest value)
        {
            var id = _personManager.Create(value);
            
            return Ok(id);
        }

          [HttpPut("update/{id}")]
        public  IActionResult Update([FromRoute] int id, [FromBody]  PersonCreateRequest value)
        {
            _personManager.Update(id,value);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _personManager.Delete(id);
         
            return Ok();
        }
    }
}
