using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingOnline.Models;
using ShoppingOnline.Query;
using ShoppingOnline.Repository.ProductRepository;
using ShoppingOnline.Repository.RatingRepository;

namespace ShoppingOnline.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRatingRepository _ratingRepository;

        public ProductService(IProductRepository productRepository, IRatingRepository ratingRepository)
        {
            _productRepository = productRepository;
            _ratingRepository = ratingRepository;
        }
        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> FilterByParameters(FilterParameters filter)
        {
            if (filter != null)
            {
                var filtering = _productRepository.GetAll();
                if (!string.IsNullOrWhiteSpace(filter.NameProduct))
                {
                    filtering = filtering.Where(p => p.Name == filter.NameProduct);
                }

                if (filter.MinPrice != null)
                {
                    filtering = filtering.Where(p => p.Price >= filter.MinPrice);
                }

                if (filter.MaxPrice != null)
                {
                    filtering = filtering.Where(p => p.Price <= filter.MaxPrice);
                }

                if (!string.IsNullOrWhiteSpace(filter.CodeProduct))
                {
                    filtering = filtering.Where(p => p.CodeProduct.Contains(filter.CodeProduct));
                }

                return filtering.ToList();
            }

            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return GetAll().FirstOrDefault(p => p.ID == id);
        }

        public Rating GetRatingById(int idProduct, int idProfile)
        {
            return _ratingRepository.GetRatingById(idProduct, idProfile);
        }

        public void AddRating(Rating newRating)
        {
             _ratingRepository.AddNewEntity(newRating);
        }
    }
}