using ShoppingOnline.Context;
using ShoppingOnline.Models;

namespace ShoppingOnline.Repository.ProductRepository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppContext context) : base(context)
        {
        }
    }
}