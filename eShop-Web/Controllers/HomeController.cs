using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eShop_Web.ViewModels;
using System.ComponentModel;
using eShop_Web.ApiClients;

namespace eShop_Web.Controllers
{
    public class HomeController : Controller
    {
        private ProductsApiClient _productsApiClient;

        public HomeController(ProductsApiClient productsApiClient)
        {
            _productsApiClient = productsApiClient;
        }

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            List<Product> pList = await _productsApiClient.GetAllProductsAsync();
            return View(pList);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
