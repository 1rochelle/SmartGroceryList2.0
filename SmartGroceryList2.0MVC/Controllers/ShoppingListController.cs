using Microsoft.AspNet.Identity;
using SmartGroceryList2._0.Models;
using SmartGroceryList2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartGroceryList2._0MVC.Controllers
{
    [Authorize]
    public class ShoppingListController : Controller
    {
        // GET: ShoppingList
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShoppingListService(userId);
            var model = service.GetShoppingLists();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShoppingListCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateShoppingListService();

            if (service.CreateShoppingList(model))
            {
                TempData["SaveResult"] = "Your shopping list was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Shopping List could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateShoppingListService();
            var model = svc.GetShoppingListById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateShoppingListService();
            var detail = service.GetShoppingListById(id);
            var model =
                new ShoppingListEdit
                {
                    Id = detail.Id,
                    CustomerId = detail.CustomerId,
                    ProductId = detail.ProductId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShoppingListEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateShoppingListService();

            if (service.UpdateShoppingList(model))
            {
                TempData["SaveResult"] = "Your shopping list was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your shopping list could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateShoppingListService();
            var model = svc.GetShoppingListById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateShoppingListService();

            service.DeleteShoppingList(id);

            TempData["SaveResult"] = "Your shopping list was deleted.";

            return RedirectToAction("Index");
        }

        private ShoppingListService CreateShoppingListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShoppingListService(userId);
            return service;
        }
    }
}