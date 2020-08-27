using ShoppingOnline.Models;

namespace ShoppingOnline.Repository.RatingRepository
{
    public interface IRatingRepository : IRepositoryBase<Rating>
    {
        Rating GetRatingById(int idProduct, int idProfile);
    }
}