using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taskSystemAPI.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Models.TaskModel>> GetAll();
        Task<Models.TaskModel> GetTaskById(long id);
        Task<Models.TaskModel> Save(Models.TaskModel task);
        Task<Models.TaskModel> Update(Models.TaskModel task,long id);
        Task<bool> DeleteById(long id);


    }
}