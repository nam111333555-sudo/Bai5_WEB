using System.Text.Json;
using BookDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookDB.Controllers;

public class CartController : Controller
{
    private const string CartSessionKey = "CartItems";
    private readonly BookDbContext _context;

    public CartController(BookDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var cart = GetCart();
        return View(new CartViewModel { Items = cart });
    }

    public async Task<IActionResult> Add(int id, int qty = 1)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.BookId == id);
        if (item == null)
        {
            cart.Add(new CartItem
            {
                BookId = book.Id,
                Title = book.Title,
                Price = book.Price,
                Quantity = Math.Max(1, qty),
                Image = book.Image
            });
        }
        else
        {
            item.Quantity += Math.Max(1, qty);
        }

        SaveCart(cart);
        TempData["CartMessage"] = $"Đã thêm '{book.Title}' vào giỏ hàng.";
        return RedirectToAction("Details", "Home", new { id });
    }

    public async Task<IActionResult> BuyNow(int id, int qty = 1)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        var cart = GetCart();
        var item = cart.FirstOrDefault(x => x.BookId == id);
        if (item == null)
        {
            cart.Add(new CartItem
            {
                BookId = book.Id,
                Title = book.Title,
                Price = book.Price,
                Quantity = Math.Max(1, qty),
                Image = book.Image
            });
        }
        else
        {
            item.Quantity += Math.Max(1, qty);
        }

        SaveCart(cart);
        TempData["CartMessage"] = $"Đã thêm '{book.Title}' vào giỏ hàng. Vui lòng kiểm tra giỏ hàng để hoàn tất mua.";
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        var cart = GetCart();
        cart.RemoveAll(x => x.BookId == id);
        SaveCart(cart);
        TempData["CartMessage"] = "Đã xóa sản phẩm khỏi giỏ hàng.";
        return RedirectToAction("Index");
    }

    public IActionResult Clear()
    {
        SaveCart(new List<CartItem>());
        TempData["CartMessage"] = "Giỏ hàng đã được làm mới.";
        return RedirectToAction("Index");
    }

    private List<CartItem> GetCart()
    {
        var json = HttpContext.Session.GetString(CartSessionKey);
        if (string.IsNullOrEmpty(json))
        {
            return new List<CartItem>();
        }

        return JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
    }

    private void SaveCart(List<CartItem> cart)
    {
        HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
    }
}
