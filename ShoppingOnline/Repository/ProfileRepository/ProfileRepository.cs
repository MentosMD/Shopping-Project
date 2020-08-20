using ShoppingOnline.Context;
using ShoppingOnline.Models;

namespace ShoppingOnline.Repository.ProfileRepository
{
    public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(AppContext context) : base(context)
        {}
    }
}