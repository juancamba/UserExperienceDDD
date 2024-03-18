using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Persistence;
using UserExperience.Domain;

namespace UserExperienceApplication.Tests.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserMockRepository()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    UserName = "juancamba",
                    Email = "juancamba@gmail.com",
                    Web = "https://juancamba.com",
                    Direccion = "Calle 123",
                },
                new User
                {
                    Id = 2,
                    UserName = "juancamba2",
                    Web = "https://juancamb2a.com",
                    Direccion = "Calle 2222",
                }
            };

            // creo un mock del repositorio
            var mockRepo = new Mock<IUserRepository>();
            // que cuando se llame al metodo GetAsync() devuelva la lista de users
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(users);

            // cuando se llama al crear, se agrega el user de tipo cualquiera a la lista
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<User>()))
                .Returns((User user) =>
                {
                    users.Add(user);
                    return Task.CompletedTask;
                });
            return mockRepo;
        }
    }
}
