using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Artisaneer.Models
{
    public class StudentVm
    {
        [Required(ErrorMessage="Please enter a First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a Last Name")]
        public string LastName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9'._%+-]+@[a-zA-Z0-9-][a-zA-Z0-9.-]*\.[a-zA-Z]{2,9}$", ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Please enter a Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a Password")]
        public string Password { get; set; }
    }
}
