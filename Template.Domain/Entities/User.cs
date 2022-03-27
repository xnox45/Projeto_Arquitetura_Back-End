using System;

namespace Template.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }
    }
}
