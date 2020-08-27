using System.Linq;
using ShoppingOnline.Context;
using ShoppingOnline.Models;

namespace ShoppingOnline.Repository.RatingRepository
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public RatingRepository(AppContext context) : base(context)
        {
        }

        public Rating GetRatingById(int idProduct, int idProfile)
        {
            return GetAll().FirstOrDefault(r => r.ProductRef == idProduct && r.ProfileRef == idProfile);
        }
    }
}