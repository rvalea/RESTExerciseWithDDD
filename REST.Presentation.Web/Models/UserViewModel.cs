using System;

namespace REST.Presentation.Web
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}