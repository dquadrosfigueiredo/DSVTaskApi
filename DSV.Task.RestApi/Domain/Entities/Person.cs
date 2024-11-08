using System.ComponentModel.DataAnnotations;


namespace DSV.Task.RestApi.Domain.Entities
{
    public class Person
    {
        public Person(int id, string? name, int height, string? birthYear, int? homeworldId, List<int>? starshipsIds)
        {
            Id = id;
            Name = name;
            Height = height;
            BirthYear = birthYear;
            HomeworldId = homeworldId;
            StarshipsIds = starshipsIds;
            Created = DateTime.UtcNow;
            Modified = DateTime.UtcNow;
        }

        [Required]
        public int Id { get; private set; }

        public string? Name { get; set; }

        public int Height { get; set; }

        public string? BirthYear { get; set; }

        public int? HomeworldId { get; set; }

        public List<int>? StarshipsIds { get; set; }

        public DateTime? Created { get; private set; } = DateTime.UtcNow;

        public DateTime? Modified { get; set; } = DateTime.UtcNow;
    }
}
