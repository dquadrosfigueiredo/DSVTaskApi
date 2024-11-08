namespace DSV.Task.RestApi.Domain.Entities
{
    public class Planet
    {
        public Planet(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string? Name { get;  set; }
        public DateTime? Created { get; private set; } = DateTime.UtcNow;

        public DateTime? Modified { get; set; } = DateTime.UtcNow;
    }
}