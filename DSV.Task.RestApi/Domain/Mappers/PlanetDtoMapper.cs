using DSV.Task.RestApi.Domain.Dtos;
using DSV.Task.RestApi.Domain.Entities;

namespace DSV.Task.RestApi.Domain.Mappers
{
    public static class PlanetDtoMapper
    {
        public static PlanetDto ToDto(this Planet planetEntity)
        {
            return new PlanetDto
            {
                Id = planetEntity.Id,   
                Name = planetEntity.Name,

            };
        }
    }
}
