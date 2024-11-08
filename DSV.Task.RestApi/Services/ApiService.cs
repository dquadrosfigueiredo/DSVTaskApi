using DSV.Task.RestApi.Controllers;
using DSV.Task.RestApi.Domain.Dtos;
using DSV.Task.RestApi.Domain.Entities;
using DSV.Task.RestApi.Domain.Mappers;
using DSV.Task.RestApi.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace DSV.Task.RestApi.Services
{
    public class ApiService
    {
        private IRepository<Person> _personRepository;
        private IRepository<Planet> _planetRepository;
        private IRepository<Starship> _starshipRepository;
        private readonly ILogger<ApiService> _logger;
        public ApiService(ILogger<ApiService> logger, IRepository<Person> personRepository, IRepository<Planet> planetRepository, IRepository<Starship> starshipRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
            _planetRepository = planetRepository;
            _starshipRepository = starshipRepository;
        }


        public List<PersonDto> GetPeople()
        {
            return _personRepository.GetAll().Select(x => x.ToDto()).ToList();
        }

        public PersonDto? GetPerson(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
                return null;

            return _personRepository.GetById(id)!.ToDto(); ;
        }

        public PersonDto CreatePerson(PersonDto personDto)
        {
            var newPerson = new Person(0, personDto.Name, personDto.Height, personDto.BirthYear, personDto.HomeworldId, personDto.StarshipsIds);
            return _personRepository.Create(newPerson).ToDto();

        }

        public PersonDto? UpdatePerson(int id, PersonDto personDto)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
                return null;

            person.Name = personDto.Name;
            person.Height = personDto.Height;
            person.BirthYear = personDto.BirthYear;
            person.HomeworldId = personDto.HomeworldId;
            person.StarshipsIds = personDto.StarshipsIds;

            return _personRepository.Update(person)!.ToDto();
        }

        public bool DeletePerson(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
                return false;

            return _personRepository.Delete(person.Id);
        }

        public List<PlanetDto> GetPlanets()
        {
            return _planetRepository.GetAll().Select(x => x.ToDto()).ToList();
        }

        public PlanetDto? GetPlanet(int id)
        {
            var planet = _planetRepository.GetById(id);
            if (planet == null)
                return null;

            return _planetRepository.GetById(id)!.ToDto(); ;
        }

        public List<StarshipDto> GetStarships()
        {
            return _starshipRepository.GetAll().Select(x => x.ToDto()).ToList();
        }

        public StarshipDto? GetStarship(int id)
        {
            var starship = _starshipRepository.GetById(id);
            if (starship == null)
                return null;

            return _starshipRepository.GetById(id)!.ToDto(); ;
        }

    }
}
