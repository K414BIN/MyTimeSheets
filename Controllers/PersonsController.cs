using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTimeSheets.Domain.Interfaces;
using MyTimeSheets.Models;
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
          
        [HttpGet]
        public IActionResult GetAll()
        { 
          var result = _personManager.GetItems();
         return Ok(result);
        }
        /// <summary>
        ///  У меня вот этот метод запрашивает вместо одно параметра id, требует почему-то два Id:
        ///  один строковый, а другой  числовой. Я не понял почему...
        ///  </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{id}")]
        public IActionResult GetOne([FromQuery] int id)
        { 
           var result = _personManager.GetItem(id);
         return Ok(result);
        }
      
        [HttpGet("from/{fromPage}/to/{toPage}")]
        public IActionResult GetPages([FromRoute] int fromPage, [FromRoute] int toPage)
        {   
            var list = _personManager.GetPages(fromPage,toPage);
            return Ok(list);
        }

        [HttpGet("name/{name}")]
          public IActionResult GetFirstName([FromRoute] string name)
        {
           var result = _personManager.GetFirstName(name);
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
