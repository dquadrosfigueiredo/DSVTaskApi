using DSV.Task.RestApi.Domain.Dtos;
using DSV.Task.RestApi.Domain.Entities;

namespace DSV.Task.RestApi.Domain.Mappers
{
    public static class PersonDtoMapper
    {
        public static PersonDto ToDto(this Person personEntity)
        {
            return new PersonDto
            {
                Id = personEntity.Id,
                Name = personEntity.Name,
                Height = personEntity.Height,
                BirthYear = personEntity.BirthYear,
                HomeworldId = personEntity.HomeworldId,
                StarshipsIds = personEntity.StarshipsIds
            };
        }
    }
}
