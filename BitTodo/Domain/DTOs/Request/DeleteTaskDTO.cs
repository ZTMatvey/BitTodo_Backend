using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTodo.Domain.DTOs.Request
{
    public sealed class DeleteTaskDTO
    {
        public Guid TaskId { get; set; }
    }
}
