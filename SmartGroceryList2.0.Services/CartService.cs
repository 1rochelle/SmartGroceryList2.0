using SmartGroceryList2._0.Data;
using SmartGroceryList2._0.Interfaces;
using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Services
{
    public class CartService 
    {
    //    private readonly Guid _userId;

    //    public CartService(Guid userId)
    //    {
    //        _userId = userId;
    //    }

    //    public bool CreateCart(CartCreate model)
    //    {
    //        var entity =
    //            new Cart()
    //            {
    //                OwnerId = _userId,
    //                CustomerId = model.CustomerId
    //            };

    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            ctx.Carts.Add(entity);
    //            return ctx.SaveChanges() == 1;
    //        }
    //    }

    //    public IEnumerable<CartListItem> GetCarts()
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var query =
    //                ctx
    //                    .Carts
    //                    .Where(e => e.OwnerId == _userId)
    //                    .Select(
    //                        e =>
    //                            new CartListItem
    //                            {
    //                                CustomerId = e.CustomerId
    //                            }
    //                    );
    //            return query.ToArray();
    //        }
    //    }

    //    public CartDetail GetCartById(int id)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                    .Carts
    //                    .Single(e => e.Id == id && e.OwnerId == _userId);
    //            return
    //                new CartDetail
    //                {
    //                    Id = entity.Id,
    //                    CustomerId = entity.CustomerId,
    //                    CartItems = entity.CartItems
    //                };
    //        }
    //    }

    //    public bool UpdateCart(CartEdit model)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                    .Carts
    //                    .Single(e => e.Id == model.Id && e.OwnerId == _userId);

    //            entity.Id = model.Id;
    //            entity.CustomerId = model.CustomerId;
    //            entity.CartItems = model.CartItems;

    //            return ctx.SaveChanges() == 1;
    //        }
    //    }

    //    public bool DeleteCart(int Id)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                    .Carts
    //                    .Single(e => e.Id == Id && e.OwnerId == _userId);

    //            ctx.Carts.Remove(entity);

    //            return ctx.SaveChanges() == 1;
    //        }
    //    }
   }
}
