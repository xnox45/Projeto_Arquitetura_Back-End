using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Models
{
    public class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }
        
        public DateTime? DeletionDate { get; set; }
    }
}
