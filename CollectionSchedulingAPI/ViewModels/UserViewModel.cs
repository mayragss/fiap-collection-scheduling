using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CollectionSchedulingAPI.ViewModels
{
    public class UserViewModel : IValidatableObject
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(12, ErrorMessage = "The password must be at least 12 characters long.")]
        [RegularExpression(@"^(?=.*\d).+$", ErrorMessage = "The password must contain at least one number.")]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            // Custom validation logic can go here if needed

            return results;
        }
    }
    public class UserLoginViewModel 
    {
        [Required]
        public string Username { get; set; }

        [Required]
         public string Password { get; set; }
    }
}
