using System.Diagnostics;
using BookDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookDB.Controllers;

public class HomeController : Controller
{
    private readonly BookDbContext _context;

    public HomeController(BookDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? categoryId)
    {
        var categories = await _context.Categories
            .Include(c => c.Books)
            .ToListAsync();

        var booksQuery = _context.Books.Include(b => b.Category).AsQueryable();

        if (categoryId.HasValue)
        {
            booksQuery = booksQuery.Where(b => b.CategoryId == categoryId.Value);
            ViewBag.SelectedCategoryId = categoryId.Value;
        }

        ViewBag.Categories = categories;
        return View(await booksQuery.ToListAsync());
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _context.Books
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null) return NotFound();

        var categories = await _context.Categories.Include(c => c.Books).ToListAsync();
        ViewBag.Categories = categories;
        return View(book);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
