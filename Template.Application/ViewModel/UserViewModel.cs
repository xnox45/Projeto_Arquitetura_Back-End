using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.ViewModel
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Mail Empty")]
        public string Mail { get; set; }
    }
}
