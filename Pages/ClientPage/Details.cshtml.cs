using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Context;
using WebApplication8.Models;

namespace WebApplication8.Pages.ClientPage
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication8.Context.Database1Context _context;

        public DetailsModel(WebApplication8.Context.Database1Context context)
        {
            _context = context;
        }

        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == id);

            if (client is not null)
            {
                Client = client;

                return Page();
            }

            return NotFound();
        }
    }
}
