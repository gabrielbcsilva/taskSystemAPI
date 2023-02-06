using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taskSystemAPI.Models
{
    public class TaskModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TaskStatus Status { get; set; }
    }
}