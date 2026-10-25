using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCore.Models;

namespace SchoolAppCore.Pages.Enrollments;

public class DetailsModel : PageModel
{
    private readonly SchoolContext _context;
    public DetailsModel(SchoolContext context)
    {
        _context = context;
    }

    public Enrollment Enrollment { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollments.FirstOrDefaultAsync(m => m.EnrollmentID == id);
        if (enrollment is null)
        {
            return NotFound();
        }
        else
        {
            Enrollment = enrollment;
        }

        return Page();
    }
}
