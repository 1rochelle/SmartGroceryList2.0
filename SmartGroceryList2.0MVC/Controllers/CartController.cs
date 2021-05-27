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
    public class CartController : Controller
    {
    //    // GET: Cart
    //    public ActionResult Index()
    //    {
    //        var userId = Guid.Parse(User.Identity.GetUserId());
    //        var service = new CartService(userId);
    //        var model = service.GetCarts();

    //        return View(model);
    //    }

    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(CartCreate model)
    //    {
    //        if (!ModelState.IsValid) return View(model);

    //        var service = CreateCartService();

    //        if (service.CreateCart(model))
    //        {
    //            TempData["SaveResult"] = "Your cart was created.";
    //            return RedirectToAction("Index");
    //        };

    //        ModelState.AddModelError("", "Cart could not be created.");
    //        return View(model);
    //    }

    //    public ActionResult Details(int id)
    //    {
    //        var svc = CreateCartService();
    //        var model = svc.GetCartById(id);

    //        return View(model);
    //    }

    //    public ActionResult Edit(int id)
    //    {
    //        var service = CreateCartService();
    //        var detail = service.GetCartById(id);
    //        var model =
    //            new CartEdit
    //            {
    //                Id = detail.Id,
    //                CustomerId = detail.CustomerId,
    //                CartItems = detail.CartItems
    //            };

    //        return View(model);
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(int id, CartEdit model)
    //    {
    //        if(!ModelState.IsValid) return View(model);

    //        if(model.Id != id)
    //        {
    //            ModelState.AddModelError("", "Id Mismatch.");
    //            return View(model);
    //        }

    //        var service = CreateCartService();

    //        if (service.UpdateCart(model))
    //        {
    //            TempData["SaveResult"] = "Your cart was updated.";
    //            return RedirectToAction("Index");
    //        }

    //        ModelState.AddModelError("", "Your cart could not be updated.");
    //        return View(model);
    //    }

    //    [ActionName("Delete")]
    //    public ActionResult Delete(int id)
    //    {
    //        var svc = CreateCartService();
    //        var model = svc.GetCartById(id);

    //        return View(model);
    //    }

    //    [HttpPost]
    //    [ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeletePost(int id)
    //    {
    //        var service = CreateCartService();

    //        service.DeleteCart(id);

    //        TempData["SaveResult"] = "Your cart was deleted.";

    //        return RedirectToAction("Index");
    //    }

    //    private CartService CreateCartService()
    //    {
    //        var userId = Guid.Parse(User.Identity.GetUserId());
    //        var service = new CartService(userId);
    //        return service;
    //    }
    }
}