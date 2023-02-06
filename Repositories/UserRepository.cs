using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taskSystemAPI.Models;

namespace taskSystemAPI.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly Data.TaskSystemDbContext _dbContext;
        public UserRepository(Data.TaskSystemDbContext taskSystemDbContext)
        {
            _dbContext = taskSystemDbContext;
        }


        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(long id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<UserModel> Save(UserModel user)
        {
           await _dbContext.Users.AddAsync(user);
           await  _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> Update(UserModel user, long id)
        {
            UserModel userById = await GetUserById(id);
            if (userById == null)
            {
                throw new Exception($"Usuário para o ID{id} não foi encontrado no banco de dados");
            }
            userById.Name = user.Name;
            userById.Email = user.Email;
            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteById(long id)
        {
            UserModel userById = await GetUserById(id);
            if (userById == null)
            {
                throw new Exception($"Usuário para o ID{id} não foi encontrado no banco de dados");
            }
            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}