using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using taskSystemAPI.Models;

namespace taskSystemAPI.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
           builder.HasKey(x=>x.Id);
           builder.Property(x=>x.Name).IsRequired().HasMaxLength(255);
           builder.Property(x=>x.Email).IsRequired().HasMaxLength(150);
        }
    }
}