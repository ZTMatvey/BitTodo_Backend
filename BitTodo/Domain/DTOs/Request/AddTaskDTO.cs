using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTodo.Domain.DTOs.Request
{
    public class AddTaskDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string GroupId { get; set; }
    }
}
