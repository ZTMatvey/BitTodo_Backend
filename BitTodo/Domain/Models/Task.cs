using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTodo.Domain.Models
{
    public class Task : EntityBase
    {
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
