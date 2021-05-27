using SmartGroceryList2._0.Data;
using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    // Terry, I don't need FirstName and LastName since I have CustomerName, with string interpolation.
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    PurchaseDate = e.PurchaseDate
                                    //OwnerId = e.OwnerId
                                }
                       );

                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer =
                    ctx
                        .Customers
                        .Where(c => c.OwnerId == _userId)
                        .SingleOrDefault(c => c.CustomerId == id);

                return new CustomerDetail
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                  //  StoreId = customer.StoreId,
                    PurchaseDate = customer.PurchaseDate
                };
            }
        }

        public bool UpdateCustomer(CustomerEdit customerEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer =
                    ctx
                        .Customers
                        .Where(c => c.OwnerId == _userId)
                        .SingleOrDefault(c => c.CustomerId == customerEdit.CustomerId);
                if (customer == null)
                {
                    return false;
                }

                customer.CustomerId = customerEdit.CustomerId;
                customer.FirstName = customerEdit.FirstName;
                customer.LastName = customerEdit.LastName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer =
                    ctx
                        .Customers
                        .Where(c => c.OwnerId == _userId)
                        .SingleOrDefault(c => c.CustomerId == id);
                if (customer == null)
                {
                    return false;
                }

                ctx.Customers.Remove(customer);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
