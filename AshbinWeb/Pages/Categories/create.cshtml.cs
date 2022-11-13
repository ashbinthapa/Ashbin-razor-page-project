using AshbinWeb.Data;
using AshbinWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AshbinWeb.Pages.Categories;
[BindProperties]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    
    public Category Category { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The DisplayOrder exactaly cannot match the name");
        }
        if (ModelState.IsValid)
        { 
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category Created Successfully.";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
