using System;

namespace Template.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }
        
        public DateTime? DeletionDate { get; set; }
    }
}
