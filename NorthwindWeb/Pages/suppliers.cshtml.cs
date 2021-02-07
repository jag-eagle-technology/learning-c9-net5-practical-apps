using Microsoft.AspNetCore.Mvc.RazorPages; 
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;
namespace NorthwindWeb.Pages
{
  public class SuppliersModel : PageModel
  {
    public IEnumerable<Supplier> Suppliers { get; set; } 
    public void OnGet()
    {
      ViewData["Title"] = "Northwind Web Site - Suppliers"; 
      Suppliers = db.Suppliers.Select(s => s);
    }
    private Northwind db;
    public SuppliersModel(Northwind injectedContext)
    {
        db = injectedContext;
    }
    [BindProperty]
    public Supplier Supplier { get; set; }
    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            db.Suppliers.Add(Supplier);
            db.SaveChanges();
            return RedirectToPage("/suppliers");
        }
        return Page();
    } 
  }
}
