using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Interfaces
{
    public interface IShoppingListService
    {
        bool CreateShoppingList(ShoppingListCreate model);

        IEnumerable<ShoppingListListItem> GetShoppingLists();

        ShoppingListDetail GetShoppingListById(int id);

        bool UpdateShoppingList(ShoppingListEdit model);

        bool DeleteShoppingList(int id);
    }
}
