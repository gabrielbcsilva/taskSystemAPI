using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taskSystemAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Models.UserModel>> GetAll();
        Task<Models.UserModel> GetUserById(long id);
        Task<Models.UserModel> Save(Models.UserModel user);
        Task<Models.UserModel> Update(Models.UserModel user,long id);
        Task<bool> DeleteById(long id);


    }
}