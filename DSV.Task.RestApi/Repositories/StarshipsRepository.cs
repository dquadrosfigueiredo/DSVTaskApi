using DSV.Task.RestApi.Domain.Entities;

namespace DSV.Task.RestApi.Repositories
{
    public class StarshipRepository : IRepository<Starship>
    {
        private const string DbFileName = "starships.json";
        private static readonly string BasePath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        private readonly List<Starship> _starshipList;

        public StarshipRepository()
        {
            _starshipList = IRepository<Starship>.LoadJsonFile(BasePath, DbFileName);

        }

        public Starship Create(Starship entity)
        {
            //simplest way of getting the next index
            int nextIndex = _starshipList.Count + 1;
            var newStarship = new Starship(
                nextIndex,
                entity.Name,
                entity.Model,
                entity.Manufacturer
                );

            _starshipList.Add(newStarship);
            IRepository<Starship>.SaveJsonFile(_starshipList, BasePath, DbFileName);
            return newStarship;

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();

        }

        public List<Starship> GetAll()
        {
            return _starshipList;
        }



        public Starship? GetById(int id)
        {
            return _starshipList.FirstOrDefault(x => x.Id == id);

        }

        public Starship? Update(Starship entity)
        {
            var starship = _starshipList.FirstOrDefault(x => x.Id == entity.Id);

            if (starship == null)
                return null;

            starship.Name = entity.Name;
            starship.Model = entity.Model;
            starship.Manufacturer = entity.Manufacturer;
            starship.Modified = DateTime.UtcNow;

            _starshipList[starship.Id] = starship;

            IRepository<Starship>.SaveJsonFile(_starshipList, BasePath, DbFileName);

            return starship;
        }



    }
}
