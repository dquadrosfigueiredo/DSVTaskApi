using DSV.Task.RestApi.Domain.Dtos;
using DSV.Task.RestApi.Domain.Entities;

namespace DSV.Task.RestApi.Domain.Mappers
{
    public static class StarshipDtoMapper
    {
        public static StarshipDto ToDto(this Starship starshipEntity)
        {
            return new StarshipDto
            {
                Id = starshipEntity.Id,
                Name = starshipEntity.Name,
                Model = starshipEntity.Model,
                Manufacturer = starshipEntity.Manufacturer,

            };
        }
    }
}
