using System;
using ShoppingOnline.Models;
using AppContext = ShoppingOnline.Context.AppContext;

namespace ShoppingOnline.Repository.UserRepository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppContext context) : base(context)
        {}
    }
}