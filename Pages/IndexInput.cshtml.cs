using ASP_NET_L2.DAL.Abstracts;
using ASP_NET_L2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_NET_L2.DAL.Entities;

namespace ASP_NET_L2.Pages
{
    public class IndexInputModel : PageModel
    {
        [BindProperty]
        public UserInputModel Input { get; set; }

        public string Name {get;set;}

        private readonly IUserRepository _userRepository;

        public IndexInputModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
            Name = "Guest";
        }
        public void OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var User = new User { 
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                CreatedDate = DateTime.Now,
            };

            _userRepository.AddUser(User);

        }
        public void OnPostDelete()
        {
            Name = "";
        }
    }
}
