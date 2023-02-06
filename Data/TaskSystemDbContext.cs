using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taskSystemAPI.Data.Map;

namespace taskSystemAPI.Data
{
    public class TaskSystemDbContext : DbContext
    {

        public TaskSystemDbContext(DbContextOptions<TaskSystemDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.UserModel> Users{get;set;}
        public DbSet<Models.TaskModel> Tasks{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}