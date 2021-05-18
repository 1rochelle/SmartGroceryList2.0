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
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StoreService(userId);
            var model = service.GetStores();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStoreService();

            if (service.CreateStore(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateStoreService();
            var model = svc.GetStoreById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStoreService();
            var detail = service.GetStoreById(id);
            var model =
                new StoreEdit
                {
                    StoreId = detail.StoreId,
                    StoreName = detail.StoreName,
                    StoreAddressNumber = detail.StoreAddressNumber,
                    StoreStreetName = detail.StoreStreetName,
                    StoreTownOrCity = detail.StoreTownOrCity,
                    StoreState = detail.StoreState,
                    StoreZIP = detail.StoreZIP
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StoreEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.StoreId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateStoreService();

            if (service.UpdateStore(model))
            {
                TempData["SaveResult"] = "The store was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The store could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStoreService();
            var model = svc.GetStoreById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateStoreService();

            service.DeleteStore(id);

            TempData["SaveResult"] = "The store was deleted.";

            return RedirectToAction("Index");
        }

        private StoreService CreateStoreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StoreService(userId);
            return service;
        }
    }
}