using System.ComponentModel.DataAnnotations;

namespace ASP_NET_L2.Models
{
    public class ProfileFormModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯіІїЇєЄґҐ\s'-]+$", ErrorMessage = "First Name can only contain letters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯіІїЇєЄґҐ\s'-]+$", ErrorMessage = "Last Name can only contain letters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Phone must be in format +380XXXXXXXXX")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [MaxLength(100, ErrorMessage = "Country cannot exceed 100 characters")]
        public string? Country { get; set; }

        [MaxLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string? City { get; set; }

        [MaxLength(500, ErrorMessage = "About Me cannot exceed 500 characters")]
        public string? AboutMe { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string? LinkedInUrl { get; set; }

        public bool IsOpenToWork { get; set; }
    }
}
