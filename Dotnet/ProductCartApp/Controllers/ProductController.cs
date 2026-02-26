using Microsoft.AspNetCore.Mvc;
using ProductCartApp.Repositories;

namespace ProductCartApp.Controllers;

public class ProductController : Controller
{
    private readonly ProductRepository _repository = new();

    public IActionResult Index()
    {
        var products = _repository.GetAll();
        return View(products);
    }
}
