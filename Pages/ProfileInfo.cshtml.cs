using ASP_NET_L2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ASP_NET_L2.Pages
{
    public class ProfileInfoModel : PageModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AboutMe { get; set; }
        public string LinkedInUrl { get; set; }
        public bool IsOpenToWork { get; set; }
        public bool HasProfile { get; set; }

        public void OnGet()
        {
            LoadProfileFromFile();
        }

        public IActionResult OnPostDelete()
        {
            string filePath = Path.Combine("Data", "profile.json");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            TempData["SuccessMessage"] = "Profile deleted successfully.";
            return RedirectToPage();
        }

        private void LoadProfileFromFile()
        {
            string filePath = Path.Combine("Data", "profile.json");

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    string jsonData = System.IO.File.ReadAllText(filePath);
                    var profile = JsonSerializer.Deserialize<ProfileFormModel>(jsonData);

                    if (profile != null)
                    {
                        FirstName = profile.FirstName;
                        LastName = profile.LastName;
                        Email = profile.Email;
                        PhoneNumber = profile.PhoneNumber;
                        Gender = profile.Gender;
                        BirthDate = profile.BirthDate;
                        Country = profile.Country;
                        City = profile.City;
                        AboutMe = profile.AboutMe;
                        LinkedInUrl = profile.LinkedInUrl;
                        IsOpenToWork = profile.IsOpenToWork;
                        HasProfile = true;
                    }
                }
                else
                {
                    HasProfile = false;
                }
            }
            catch
            {
                HasProfile = false;
            }
        }
    }
}
