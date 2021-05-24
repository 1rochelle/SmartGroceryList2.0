using SmartGroceryList2._0.Data;
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
        private readonly Guid _userId;

        public CartService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCart(CartCreate model)
        {
            var entity =
                new Cart()
                {
                    OwnerId = _userId,
                    ProductId = model.ProductId,
                    CustomerId = model.CustomerId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Carts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CartListItem> GetCarts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Carts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CartListItem
                                {
                                    CustomerId = e.CustomerId,
                                    ProductId = e.ProductId
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
