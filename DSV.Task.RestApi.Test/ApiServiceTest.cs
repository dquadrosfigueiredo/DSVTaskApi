using DSV.Task.RestApi.Domain.Entities;
using DSV.Task.RestApi.Repositories;
using DSV.Task.RestApi.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace DSV.Task.RestApi.Test
{
    public class ApiServiceTest
    {
        [Fact]
        public void Deleting_Non_Existing_Person_Yields_False()
        {
            Mock<IRepository<Person>> personRepoMock = new Mock<IRepository<Person>>();
            Mock<IRepository<Planet>> planetRepoMock = new Mock<IRepository<Planet>>();
            Mock<IRepository<Starship>> starshipRepoMock = new Mock<IRepository<Starship>>();
            Mock<ILogger<ApiService>> loggerMock = new Mock<ILogger<ApiService>>();

            personRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns<Person>(null!);


            ApiService apiService = new ApiService(loggerMock.Object, personRepoMock.Object, planetRepoMock.Object, starshipRepoMock.Object);
            Assert.False(apiService.DeletePerson(1));
        }
    }
}