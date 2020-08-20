using System.Collections.Generic;
using ShoppingOnline.Models;
using ShoppingOnline.Query;

namespace ShoppingOnline.Services.ProductService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> FilterByParameters(FilterParameters filter);
    }
}