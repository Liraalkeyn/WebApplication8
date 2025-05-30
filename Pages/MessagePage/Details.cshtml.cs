using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Context;
using WebApplication8.Models;

namespace WebApplication8.Pages.MessagePage
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication8.Context.Database1Context _context;

        public DetailsModel(WebApplication8.Context.Database1Context context)
        {
            _context = context;
        }

        public Message Message { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages.FirstOrDefaultAsync(m => m.MessageId == id);

            if (message is not null)
            {
                Message = message;

                return Page();
            }

            return NotFound();
        }
    }
}
