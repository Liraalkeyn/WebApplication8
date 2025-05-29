using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.Context;
using WebApplication8.Models;

namespace WebApplication8.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication8.Context.Database1Context _context;

        public CreateModel(WebApplication8.Context.Database1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "RequestId");
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Feedbacks.Add(Feedback);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
