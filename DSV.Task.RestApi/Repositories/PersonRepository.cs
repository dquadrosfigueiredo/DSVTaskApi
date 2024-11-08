using DSV.Task.RestApi.Domain.Entities;
using System.Text.Json;

namespace DSV.Task.RestApi.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private const string DbFileName = "people.json";
        private static readonly string BasePath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        private readonly List<Person> _personList;

        public PersonRepository()
        {
            _personList = IRepository<Person>.LoadJsonFile(BasePath, DbFileName);

        }

        public Person Create(Person entity)
        {
            //simplest way of getting the next index in this scenario
            int nextIndex = _personList.Count + 1;
            var newPerson = new Person(
                nextIndex,
                entity.Name,
                entity.Height,
                entity.BirthYear,
                entity.HomeworldId,
                entity.StarshipsIds);

            _personList.Add(newPerson);
            IRepository<Person>.SaveJsonFile(_personList, BasePath, DbFileName);
            return newPerson;

        }

        public bool Delete(int id)
        {
            var person = _personList.FirstOrDefault(x => x.Id == id);

            if (person == null)
                return false;

            _personList.Remove(person);
            IRepository<Person>.SaveJsonFile(_personList, BasePath, DbFileName);
            return true;

        }

        public List<Person> GetAll()
        {
            return _personList;
        }



        public Person? GetById(int id)
        {
            return _personList.FirstOrDefault(x => x.Id == id);

        }

        public Person? Update(Person entity)
        {
            var person = _personList.FirstOrDefault(x => x.Id == entity.Id);

            if (person == null)
                return null;

            person.Name = entity.Name;
            person.Height = entity.Height;
            person.BirthYear = entity.BirthYear;
            person.HomeworldId = entity.HomeworldId;
            person.StarshipsIds = entity.StarshipsIds;
            person.Modified = DateTime.UtcNow;



            IRepository<Person>.SaveJsonFile(_personList, BasePath, DbFileName);

            return person;

        }

    }
}
