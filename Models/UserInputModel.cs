using System.ComponentModel.DataAnnotations;

namespace ASP_NET_L2.Models
{
    public class UserInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; }

    }
}
