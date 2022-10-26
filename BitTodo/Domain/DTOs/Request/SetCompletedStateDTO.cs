using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTodo.Domain.DTOs.Request
{
    public sealed class SetCompletedStateDTO
    {
        public Guid TaskId { get; set; }
        public bool State { get; set; }
    }
}
