using Microsoft.AspNetCore.Mvc;
using ProductCartApp.Extensions;
using ProductCartApp.Models;
using ProductCartApp.Repositories;

namespace ProductCartApp.Controllers;

public class CartController : Controller
{
    private readonly ProductRepository _repository = new();
    private const string CartSessionKey = "CartSession";

    public IActionResult Index()
    {
        var cart = HttpContext.Session.Get<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
        ViewBag.Total = cart.Sum(i => i.Product.Price * i.Quantity);
        return View(cart);
    }

    public IActionResult AddToCart(int id)
    {
        var product = _repository.GetById(id);
        if (product == null) return NotFound();

        var cart = HttpContext.Session.Get<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
        var item = cart.FirstOrDefault(i => i.Product.Id == id);

        if (item == null)
        {
            cart.Add(new CartItem { Product = product, Quantity = 1 });
        }
        else
        {
            item.Quantity++;
        }

        HttpContext.Session.Set(CartSessionKey, cart);
        return RedirectToAction("Index", "Product");
    }

    public IActionResult RemoveFromCart(int id)
    {
        var cart = HttpContext.Session.Get<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
        var item = cart.FirstOrDefault(i => i.Product.Id == id);

        if (item != null)
        {
            cart.Remove(item);
        }

        HttpContext.Session.Set(CartSessionKey, cart);
        return RedirectToAction("Index");
    }

    public IActionResult Clear()
    {
        HttpContext.Session.Remove(CartSessionKey);
        return RedirectToAction("Index");
    }
}
