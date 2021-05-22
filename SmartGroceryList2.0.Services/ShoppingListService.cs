﻿using SmartGroceryList2._0.Data;
using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Services
{
    public class ShoppingListService
    {
        private readonly Guid _userId;

        public ShoppingListService(Guid userId)
        {
            _userId = userId;
        }

        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public bool CreateShoppingList(ShoppingListCreate model)
        {
            List<string> BaggedSalad = new List<string>();
            List<string> Cheerios = new List<string>();
            List<string> Pledge = new List<string>();
            List<string> CatLitter = new List<string>();
            List<string> SkimMilk = new List<string>();
            List<string> HalfAndHalf = new List<string>();
            List<string> Lemons = new List<string>();
            List<string> Oranges = new List<string>();
            List<string> ToiletPaper = new List<string>();
            List<string> GroundBeef = new List<string>();
            List<string> IceCream = new List<string>();
            List<string> YogurtDressing = new List<string>();

            //each instance of CreatedUTC in a list 
            DateTimeOffset BaggedSaladPurchased = new DateTimeOffset();
            DateTimeOffset CheeriosPurchased = new DateTimeOffset();
            DateTimeOffset PledgePurchased = new DateTimeOffset();
            DateTimeOffset CatLitterPurchased = new DateTimeOffset();
            DateTimeOffset SkimMilkPurchased = new DateTimeOffset();
            DateTimeOffset HalfAndHalfPurchased = new DateTimeOffset();
            DateTimeOffset LemonsPurchased = new DateTimeOffset();
            DateTimeOffset OrangesPurchased = new DateTimeOffset();
            DateTimeOffset ToiletPaperPurchased = new DateTimeOffset();
            DateTimeOffset GroundBeefPurchased = new DateTimeOffset();
            DateTimeOffset IceCreamPurchased = new DateTimeOffset();
            DateTimeOffset YogurtDressingPurchased = new DateTimeOffset();

            //using (var ProductDb = new ApplicationDbContext()) { };
            foreach (Product EachItem in db.Products)
            {
                string ProductName = EachItem.ItemName;
                switch (ProductName.ToLower())
                {
                    case "baggedsalad":
                        BaggedSalad.Add(ProductName);
                        if (BaggedSalad.Count() == 1)
                        {
                            BaggedSaladPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "cheerios":
                        Cheerios.Add(ProductName);
                        if (Cheerios.Count() == 1)
                        {
                            CheeriosPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "pledge":
                        Pledge.Add(ProductName);
                        if (Pledge.Count() == 1)
                        {
                            PledgePurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "catlitter":
                        CatLitter.Add(ProductName);
                        if (CatLitter.Count() == 1)
                        {
                            CatLitterPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "skimmilk":
                        SkimMilk.Add(ProductName);
                        if (SkimMilk.Count() == 1)
                        {
                            SkimMilkPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "halfandhalf":
                        HalfAndHalf.Add(ProductName);
                        if (HalfAndHalf.Count() == 1)
                        {
                            HalfAndHalfPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "lemons":
                        Lemons.Add(ProductName);
                        if (Lemons.Count() == 1)
                        {
                            LemonsPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "oranges":
                        Oranges.Add(ProductName);
                        if (Oranges.Count() == 1)
                        {
                            OrangesPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "toiletpaper":
                        ToiletPaper.Add(ProductName);
                        if (ToiletPaper.Count() == 1)
                        {
                            ToiletPaperPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "groundbeef":
                        GroundBeef.Add(ProductName);
                        if (GroundBeef.Count() == 1)
                        {
                            GroundBeefPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "icecream":
                        IceCream.Add(ProductName);
                        if (IceCream.Count() == 1)
                        {
                            IceCreamPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    case "yogurtdressing":
                        YogurtDressing.Add(ProductName);
                        if (YogurtDressing.Count() == 1)
                        {
                            YogurtDressingPurchased = EachItem.CreatedUtc;
                        }
                        break;
                    default:
                        Console.WriteLine("That product doesn't exist.");
                        break;
                }
            }

            DateTimeOffset Today = new DateTimeOffset();

            //foreach List compare CreatedUTCs
            var entity =

                new ShoppingList()
                {
                    OwnerId = _userId,
                    Id = model.Id,
                    CustomerId = model.CustomerId,
                    ProductId = model.ProductId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShoppingListListItem> GetShoppingLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ShoppingLists
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new ShoppingListListItem
                            {
                                Id = e.Id,
                                CustomerId = e.CustomerId,
                                ProductId = e.ProductId
                            }
                       );

                return query.ToArray();
            }
        }

        public ShoppingListDetail GetShoppingListById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ShoppingLists
                        .Single(e => e.Id == id && e.OwnerId == _userId);
                return
                    new ShoppingListDetail
                    {
                        Id = entity.Id,
                        CustomerId = entity.CustomerId,
                        ProductId = entity.ProductId
                    };
            }
        }

        public bool UpdateShoppingList(ShoppingListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ShoppingLists
                        .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.Id = model.Id;
                entity.CustomerId = model.CustomerId;
                entity.ProductId = model.ProductId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShoppingList(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ShoppingLists
                        .Single(e => e.Id == id && e.OwnerId == _userId);

                ctx.ShoppingLists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}