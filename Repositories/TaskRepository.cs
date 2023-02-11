using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taskSystemAPI.Models;

namespace taskSystemAPI.Repositories.Interfaces
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Data.TaskSystemDbContext _dbContext;
        public TaskRepository(Data.TaskSystemDbContext taskSystemDbContext)
        {
            _dbContext = taskSystemDbContext;
        }


        public async Task<List<TaskModel>> GetAll()
        {
            return await _dbContext.Tasks.Include(x=>x.User).ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(long id)
        {
            return await _dbContext.Tasks. 
            Include(x=>x.User).
            FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<TaskModel> Save(TaskModel task)
        {
           await _dbContext.Tasks.AddAsync(task);
           await  _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> Update(TaskModel task, long id)
        {
            TaskModel taskById = await GetTaskById(id);
            if (taskById == null)
            {
                throw new Exception($"Tarefa para o ID{id} não foi encontrado no banco de dados");
            }
            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;
            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> DeleteById(long id)
        {
            TaskModel taskById = await GetTaskById(id);
            if (taskById == null)
            {
                throw new Exception($"Tarefa para o ID{id} não foi encontrado no banco de dados");
            }
            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}