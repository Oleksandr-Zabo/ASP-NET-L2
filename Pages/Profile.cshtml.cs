using ASP_NET_L2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ASP_NET_L2.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public ProfileFormModel Form { get; set; }

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

        public void OnGet(bool skipLoad = false)
        {
            if (!skipLoad)
            {
                LoadProfileFromFile();
            }
            else
            {
                FirstName = "Guest";
                Form = new ProfileFormModel();
            }
        }

        public IActionResult OnPostSave()
        {
            if (Form == null)
            {
                ModelState.AddModelError(string.Empty, "Form data is null");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Copy form data to display properties
                FirstName = Form.FirstName;
                LastName = Form.LastName;
                Email = Form.Email;
                PhoneNumber = Form.PhoneNumber;
                Gender = Form.Gender;
                BirthDate = Form.BirthDate;
                Country = Form.Country;
                City = Form.City;
                AboutMe = Form.AboutMe;
                LinkedInUrl = Form.LinkedInUrl;
                IsOpenToWork = Form.IsOpenToWork;

                SaveProfileToFile();
                TempData["SuccessMessage"] = "Saved successfully.";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error saving profile: {ex.Message}");
                return Page();
            }
            
            return Page();
        }

        public IActionResult OnPostReset()
        {
            TempData["SuccessMessage"] = "Form reset successfully.";
            return RedirectToPage(new { skipLoad = true });
        }

        public IActionResult OnPostDelete()
        {
            string filePath = Path.Combine("Data", "profile.json");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            TempData["SuccessMessage"] = "Profile deleted successfully.";
            return RedirectToPage(new { skipLoad = true });
        }

        private void SaveProfileToFile()
        {
            string dataFolder = "Data";
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            string filePath = Path.Combine(dataFolder, "profile.json");
            string jsonData = JsonSerializer.Serialize(Form, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });

            System.IO.File.WriteAllText(filePath, jsonData);
        }

        private void LoadProfileFromFile()
        {
            string filePath = Path.Combine("Data", "profile.json");

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    string jsonData = System.IO.File.ReadAllText(filePath);
                    Form = JsonSerializer.Deserialize<ProfileFormModel>(jsonData);

                    if (Form != null)
                    {
                        FirstName = Form.FirstName;
                        LastName = Form.LastName;
                        Email = Form.Email;
                        PhoneNumber = Form.PhoneNumber;
                        Gender = Form.Gender;
                        BirthDate = Form.BirthDate;
                        Country = Form.Country;
                        City = Form.City;
                        AboutMe = Form.AboutMe;
                        LinkedInUrl = Form.LinkedInUrl;
                        IsOpenToWork = Form.IsOpenToWork;
                    }
                }
                else
                {
                    FirstName = "Guest";
                    Form = new ProfileFormModel();
                }
            }
            catch
            {
                FirstName = "Guest";
                Form = new ProfileFormModel();
            }
        }
    }
}
