using CalculatorApp.Models;
using CalculatorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers;

public class CalculatorController : Controller
{
    private readonly AddService _addService;
    private readonly MultiplyService _multiplyService;

    public CalculatorController(AddService addService, MultiplyService multiplyService)
    {
        _addService = addService;
        _multiplyService = multiplyService;
    }

    public IActionResult Index()
    {
        return View(new CalculatorModel());
    }

    [HttpPost]
    public IActionResult Calculate(CalculatorModel model, string operation)
    {
        if (operation == "add")
        {
            model.Result = _addService.Add(model.Number1, model.Number2);
            model.Operation = "Addition";
        }
        else if (operation == "multiply")
        {
            model.Result = _multiplyService.Multiply(model.Number1, model.Number2);
            model.Operation = "Multiplication";
        }

        return View("Index", model);
    }
}
