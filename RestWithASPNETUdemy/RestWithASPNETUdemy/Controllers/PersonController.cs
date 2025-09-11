using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Interfaces;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var persons = _personService.FindAll();
            return Ok(persons);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Person> Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _personService.Create(person);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _personService.Update(person);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}