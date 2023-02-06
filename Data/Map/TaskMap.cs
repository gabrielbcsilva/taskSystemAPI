using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using taskSystemAPI.Models;

namespace taskSystemAPI.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {

        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
           builder.HasKey(x=>x.Id);
           builder.Property(x=>x.Name).IsRequired().HasMaxLength(255);
           builder.Property(x=>x.Description).HasMaxLength(1000);
           builder.Property(x=>x.Status).IsRequired();
        }
    }
}