using Microsoft.AspNetCore.Mvc;
using GadgetInventory.Models;
using System.Collections.Generic;

namespace GadgetInventory.Controllers
{
    public class GadgetController : Controller
    {
        // In-memory data storage
        private static List<Gadget> gadgets = new List<Gadget>
        {
            new Gadget { Id = 1, Brand = "Apple", ModelName = "iPhone 15", Price = 799.00m },
            new Gadget { Id = 2, Brand = "Samsung", ModelName = "Galaxy S24", Price = 849.00m }
        };
        
        // GET: /Gadget/Index
        public IActionResult Index()
        {
            return View(gadgets);
        }

        // GET: /Gadget/Create (Displays the blank form)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Gadget/Create (Processes the form submission)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gadget newGadget)
        {
            if (!ModelState.IsValid)
            {
                return View(newGadget); // Return form with validation errors
            }

            newGadget.Id = gadgets.Count + 1; 
            gadgets.Add(newGadget);

            return RedirectToAction("Index"); // PRG Pattern
        }
    }
}