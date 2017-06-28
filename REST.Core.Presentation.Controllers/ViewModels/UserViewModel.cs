using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Core.Presentation.Controllers
{
    public class UserViewModel
    {
        public long? UserId { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
