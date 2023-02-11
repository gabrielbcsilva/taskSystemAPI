using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using taskSystemAPI.Models;
using taskSystemAPI.Repositories.Interfaces;

namespace taskSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        public UserController(IUserRepository userRepository){
            _userRepository = userRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>>  ListUsers(){
           List<UserModel> users = await _userRepository.GetAll();
           return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>>  GetById(long id){
           UserModel user = await _userRepository.GetUserById(id);
           return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>>  Save([FromBody] UserModel userModel){
           UserModel user = await _userRepository.Save(userModel);
           return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>>  Update([FromBody] UserModel userModel,long id){
           UserModel user = await _userRepository.Update(userModel,id);
           return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>>  Delete(long id){
           Boolean deleted = await _userRepository.DeleteById(id);
           return Ok(deleted);
        }
    }
}