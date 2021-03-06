using SmartGroceryList2._0.Data;
using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool CreateShoppingList(ShoppingListCreate model)
        {
            var entity =

                new ShoppingList()
                {
                    OwnerId = _userId,
                    CartId = model.CartId,
                    ProductId = model.ProductId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //public List<ShoppingList> SmartList(ShoppingListCreate model)
        //{
        //    using (var ctx = new ApplicationDbContext())




        //}



        

        //public CreateSmartList

    
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
                                CartId = e.CartId,
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
                        CartId = entity.CartId,
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
                entity.CartId = model.CartId;
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
