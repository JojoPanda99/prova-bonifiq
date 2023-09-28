using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class ProductService
    {
        private readonly int ItemPerPage = 10;
        private IProductRepository ProductRepository { get; set; }

        public ProductService(IProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }

        public ProductList ListProducts(int page)
        {
            var productQueryable = ProductRepository.FindAllQueryable();
            var listProducts = productQueryable.Skip(page * ItemPerPage).Take(ItemPerPage).ToList();
            var hasNext = (productQueryable.Count() / ItemPerPage) > (page + 1);

            return new ProductList() { HasNext = hasNext, TotalCount = listProducts.Count(), Products = listProducts };
        }
    }
}