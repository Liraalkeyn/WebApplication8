using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Context;
using WebApplication8.Models;

namespace WebApplication8.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication8.Context.Database1Context _context;

        public DeleteModel(WebApplication8.Context.Database1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Request Request { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FirstOrDefaultAsync(m => m.RequestId == id);

            if (request is not null)
            {
                Request = request;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request != null)
            {
                Request = request;
                _context.Requests.Remove(Request);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
