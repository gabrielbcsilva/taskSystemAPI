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
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        
        public TaskController(ITaskRepository taskRepository){
            _taskRepository = taskRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>>  ListUsers(){
           List<TaskModel> tasks = await _taskRepository.GetAll();
           return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>>  GetById(long id){
           TaskModel task = await _taskRepository.GetTaskById(id);
           return Ok(task);
        }
        [HttpPost]
        public async Task<ActionResult<TaskModel>>  Save([FromBody] TaskModel taskModel){
           TaskModel task = await _taskRepository.Save(taskModel);
           return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>>  Update([FromBody] TaskModel taskModel,long id){
           TaskModel task = await _taskRepository.Update(taskModel,id);
           return Ok(task);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>>  Delete(long id){
           Boolean deleted = await _taskRepository.DeleteById(id);
           return Ok(deleted);
        }
    }
}