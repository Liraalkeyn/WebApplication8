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
    public class IndexModel : PageModel
    {
        private readonly WebApplication8.Context.Database1Context _context;

        public IndexModel(WebApplication8.Context.Database1Context context)
        {
            _context = context;
        }

        public IList<Message> Message { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Message = await _context.Messages
                .Include(m => m.Master)
                .Include(m => m.Request).ToListAsync();
        }
    }
}
