using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Interfaces
{
    public interface ICartService
    {
        bool CreateCart(CartCreate model);

        IEnumerable<CartListItem> GetCarts();

        CartDetail GetCartById(int id);

        bool UpdateCart(CartEdit model);

        bool DeleteCart(int Id);


    }
}
