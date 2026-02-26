using ProductCartApp.Models;

namespace ProductCartApp.Repositories;

public class ProductRepository
{
    private static readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Quantum Laptop", Price = 1299.99m, Description = "Next-gen computing power with holographic display.", ImageUrl = "/images/laptop.jpg" },
        new Product { Id = 2, Name = "Neural Buds", Price = 199.99m, Description = "High-fidelity audio with direct brain link.", ImageUrl = "/images/buds.jpg" },
        new Product { Id = 3, Name = "Aero Watch", Price = 349.50m, Description = "Floating interface and health monitoring.", ImageUrl = "/images/watch.jpg" },
        new Product { Id = 4, Name = "Vortex VR", Price = 599.00m, Description = "Full-immersion virtual reality headset.", ImageUrl = "/images/vr.jpg" }
    };

    public List<Product> GetAll() => _products;
    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
}
