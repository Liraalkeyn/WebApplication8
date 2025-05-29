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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication8.Context.Database1Context _context;

        public DetailsModel(WebApplication8.Context.Database1Context context)
        {
            _context = context;
        }

        public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks.FirstOrDefaultAsync(m => m.FeedbackId == id);

            if (feedback is not null)
            {
                Feedback = feedback;

                return Page();
            }

            return NotFound();
        }
    }
}
