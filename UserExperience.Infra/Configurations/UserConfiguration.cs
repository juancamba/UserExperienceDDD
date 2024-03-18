using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Domain;

namespace UserExperience.Infra.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "juancamba",
                    Email = "juancamba@gmail.com",
                    Web = "https://juancamba.com",
                    Direccion = "Calle 123",
                });
        }
    }
}
