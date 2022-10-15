using AdventureWorks2019BE.DTOs.AdventureWorks.PersonArea;
using AdventureWorks2019BE.Services.AdventureWorks.PersonArea;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks2019BE.Controllers.AdventureWorks.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonService _servicePerson;

        public PersonController(ILogger<PersonController> logger, PersonService servicePerson)
        {
            _logger = logger;
            _servicePerson = servicePerson;
        }


        /*      #############
         *      # GET /[id] #
         *      #############
         *  Scheda della person */
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            PersonDTO personDTO = await _servicePerson.GetById(id);
            return Ok(personDTO);
        }
    }
}
