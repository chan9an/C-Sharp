using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;
using System.Text;
using System.Text.Json;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client;

        public ProductController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync("product");

            var data = await response.Content.ReadAsStringAsync();

            var products = JsonSerializer.Deserialize<List<Product>>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var json = JsonSerializer.Serialize(product);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync("product", content);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await client.DeleteAsync($"product/{id}");

            return RedirectToAction("Index");
        }
    }
}
