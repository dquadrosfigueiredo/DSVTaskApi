using DSV.Task.RestApi.Domain.Entities;

namespace DSV.Task.RestApi.Domain.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Height { get; set; }
        public string? BirthYear { get; set; }

        public int? HomeworldId { get; set; }
        public List<int>? StarshipsIds { get; set; }

    }
}
