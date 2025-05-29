using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication8.Context;
using WebApplication8.Models;

namespace WebApplication8.Pages
{
    public class LoginModel : PageModel
    {
        public string Message { get; set; } = "Please log in to continue.";
        private readonly Context.Database1Context _context;

        public LoginModel(Context.Database1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = new User();
        public string ErrorMessage { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Check if the user exists in the database
                var existingUser = _context.Users.FirstOrDefault(u => u.Login == User.Password && u.Password == User.Password);
                if (existingUser != null)
                {
                    // User found, redirect to the home page or another page
                    return RedirectToPage("/Index");
                }
                else
                {
                    // User not found, set an error message
                    ErrorMessage = "Invalid username or password.";
                }
            }
            return Page(); // Return the current page with validation errors
        }

        //public void OnGet()
        //{
        //    // This method is called on GET requests to the Login page.
        //    // You can initialize any data or perform actions needed when the page is accessed.
        //}
    }
}
