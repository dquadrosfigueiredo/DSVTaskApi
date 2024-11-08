using DSV.Task.RestApi.Domain.Entities;
using System.Text.Json;

namespace DSV.Task.RestApi.Repositories
{
    public class PlanetRepository : IRepository<Planet>
    {
        private const string DbFileName = "planets.json";
        private static readonly string BasePath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        private readonly List<Planet> _planetList;

        public PlanetRepository()
        {
            _planetList = IRepository<Planet>.LoadJsonFile(BasePath, DbFileName);

        }

        public Planet Create(Planet entity)
        {
            //simplest way of getting the next index
            int nextIndex = _planetList.Count + 1;
            var newPlanet = new Planet(
                nextIndex,
                entity.Name);

            _planetList.Add(newPlanet);
            IRepository<Planet>.SaveJsonFile(_planetList, BasePath, DbFileName);
            return newPlanet;

        }

        public bool Delete(int id)
        {
            int planetId = _planetList.FindIndex(x => x.Id == id);
            if (planetId > 0)
            {
                return false;
            }
            _planetList.RemoveAt(id);
            IRepository<Planet>.SaveJsonFile(_planetList, BasePath, DbFileName);
            return true;

        }

        public List<Planet> GetAll()
        {
            return _planetList;
        }



        public Planet? GetById(int id)
        {
            return _planetList.FirstOrDefault(x => x.Id == id);

        }

        public Planet? Update(Planet entity)
        {
            var planet = _planetList.FirstOrDefault(x => x.Id == entity.Id);

            if (planet == null)
                return null;

            planet.Name = entity.Name;
            planet.Modified = DateTime.UtcNow;

            _planetList[planet.Id] = planet;

            IRepository<Planet>.SaveJsonFile(_planetList, BasePath, DbFileName);

            return planet;
        }

    }
}
