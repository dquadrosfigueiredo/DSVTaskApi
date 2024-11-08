namespace DSV.Task.RestApi.Domain.Entities
{
    public class Starship
    {
        public Starship(int id, string? name, string? model, string? manufacturer)
        {
            Id = id;
            Name = name;
            Model = model;
            Manufacturer = manufacturer;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }
        public DateTime? Created { get; private set; } = DateTime.UtcNow;

        public DateTime? Modified { get; set; } = DateTime.UtcNow;
    }
}