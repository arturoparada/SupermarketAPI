using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Data;
using SupermarketAPI.Models;
using System.Collections.Generic;

namespace SupermarketAPI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http get index
        public IActionResult Index()
        {
            IEnumerable<Product> listPorducts = _context.Product;
            return View(listPorducts);
        }
        
        
        //Http get create
        //Carga la vista del formulario para creación de productos
        //[Route("products/0")]
        public IActionResult Create()
        {
            return View();
        }
        //Http post create
        //Valida el modelo del producto y crea el registro
        [HttpPost]
        //[Route("products/0")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                TempData["mensaje"] = "Se ha agregado el articulo";
                return RedirectToAction("Index");
            }
            return View();
        }


        //Http get edit
        //[Route("products/edit/")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //carga informacion de producto a la vista
            var product = _context.Product.Find(id);

            // valida si existe el producto
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //Http post edit
        //Valida el modelo del producto y edita el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Product.Update(product);
                _context.SaveChanges();

                TempData["mensaje"] = "Se ha actualizado el articulo";
                return RedirectToAction("Index");
            }
            return View();
        }


        //Http get delete, obtiene el formulario
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //carga informacion de producto
            var product = _context.Product.Find(id);

            // valida si existe el producto
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //Http post delete       
       [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? id)
        {
            //Encuentra articulo por id
            var product = _context.Product.Find(id);

            if (product == null)
            {
                return NotFound();
            }
            _context.Product.Remove(product);
            _context.SaveChanges();

            TempData["mensaje"] = "Se eliminó el articulo";
            return RedirectToAction("Index");
        }
    }
}