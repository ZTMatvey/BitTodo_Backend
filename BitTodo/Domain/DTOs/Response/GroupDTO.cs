using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTodo.Domain.DTOs.Response
{
    public sealed class GroupDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
