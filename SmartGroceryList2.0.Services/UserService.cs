using SmartGroceryList2._0.Data;
using SmartGroceryList2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGroceryList2._0.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserId = _userId,
                    UserName = model.UserName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                            new UserListItem
                            {
                                UserId = e.UserId,
                                UserName = e.UserName,
                                CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }

        //public UserDetail GetUsersById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Users
        //                .Single(e => e.UserId == id && e.UserId == _userId);
        //        return
        //            new UserDetail
        //            {
        //                UserId = entity.UserId,
        //                UserName = entity.UserName,
        //                HasPurchaseHistory = entity.HasPurchaseHistory
        //            };
        //    }
        //}

        //public bool UpdateUser(UserEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Users
        //                .Single(e => e.UserId == model.UserId && e.UserId == _userId);

        //        entity.UserId = model.UserId;
        //        entity.UserName = model.UserName;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        //public bool DeleteUser(int userId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Users
        //                .Single(e => e.UserId == userId && e.UserId == _userId);

        //        ctx.Notes.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}
