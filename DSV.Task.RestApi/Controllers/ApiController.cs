using DSV.Task.RestApi.Domain.Dtos;
using DSV.Task.RestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSV.Task.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {


        private readonly ILogger<ApiController> _logger;
        private readonly ApiService _apiService;

        public ApiController(ILogger<ApiController> logger, ApiService personService)
        {
            _logger = logger;
            _apiService = personService;
        }

        [HttpGet]
        [Route("people/")]
        public IActionResult GetPeople()
        {
            _logger.LogInformation("GetPeople method requested");
            return Ok(_apiService.GetPeople());
        }

        [HttpGet]
        [Route("people/{id}")]
        public IActionResult GetPerson(int id)
        {
            _logger.LogInformation("GetPerson by Id method requested");
            var person = _apiService.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(_apiService.GetPerson(id));
        }

        [HttpPost]
        [Route("people/")]
        public IActionResult CreatePerson(PersonDto person)
        {
            _logger.LogInformation("CreatePerson method requested");

            if (person == null)
            {
                return BadRequest();
            }
            var personDto = _apiService.CreatePerson(person);

            return Ok(new
            {
                message = "Person Created Successfully!!!",
                name = personDto!.Name
            });
        }

        [HttpPut]
        [Route("people/{id}")]
        public IActionResult UpdatePerson(int id, PersonDto person)
        {
            _logger.LogInformation("UpdatePerson by Id method requested");
            var personToUpdate = _apiService.UpdatePerson(id, person);
            if (personToUpdate == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Person updated",
                id = personToUpdate!.Name
            });
        }

        [HttpDelete]
        [Route("people/{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (!_apiService.DeletePerson(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Person deleted",
                id = id
            });
        }



        [HttpGet]
        [Route("planets/")]
        public IActionResult GetPlanets()
        {
            _logger.LogInformation("GetPlanets method requested");
            return Ok(_apiService.GetPlanets());
        }

        [HttpGet]
        [Route("planets/{id}")]
        public IActionResult GetPlanetById(int id)
        {
            _logger.LogInformation("GetPlanetById by Id method requested");
            var planet = _apiService.GetPlanet(id);
            if (planet == null)
            {
                return NotFound();
            }
            return Ok(_apiService.GetPlanet(id));
        }

        [HttpGet]
        [Route("starships/")]
        public IActionResult GetStarships()
        {
            _logger.LogInformation("GetStarships method requested");
            return Ok(_apiService.GetStarships());
        }

        [HttpGet]
        [Route("starships/{id}")]
        public IActionResult GetStarshipById(int id)
        {
            _logger.LogInformation("GetStarshipById by Id method requested");
            var starship = _apiService.GetStarship(id);
            if (starship == null)
            {
                return NotFound();
            }
            return Ok(_apiService.GetStarship(id));
        }


    }
}
