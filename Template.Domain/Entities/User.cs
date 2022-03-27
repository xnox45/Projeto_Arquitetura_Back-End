using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }
    }
}
