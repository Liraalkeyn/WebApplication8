using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Context;
using WebApplication8.Models;

namespace WebApplication8.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebApplication8.Context.Database1Context _context;

        public EditModel(WebApplication8.Context.Database1Context context)
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

            var request =  await _context.Requests.FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }
            Request = request;
           ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
           ViewData["MasterId"] = new SelectList(_context.Masters, "MasterId", "MasterId");
           ViewData["RepairPartsId"] = new SelectList(_context.RepairParts, "RepairPartId", "RepairPartId");
           ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "RequestStatusId");
           ViewData["TechTypeId"] = new SelectList(_context.TechTypes, "TechTypeId", "TechTypeId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(Request.RequestId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestId == id);
        }
    }
}
