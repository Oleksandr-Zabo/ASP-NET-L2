using ASP_NET_L2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_NET_L2.Pages
{
    public class IndexInputModel : PageModel
    {
        [BindProperty]
        public UserInputModel Input { get; set; }

        public string Name {get;set;}
       
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
        }
        public void OnPostDelete()
        {
            Name = "";
        }
    }
}
