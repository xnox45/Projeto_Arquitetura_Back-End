using System;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Mail { get; set; }
    }
}
