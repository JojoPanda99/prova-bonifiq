using ProvaPub.Dtos;
using ProvaPub.Models;

namespace ProvaPub.Interfaces.Services;

public interface IProductService
{
    Task<ProductsPaginatedDto> ListProductsAsync(int page);
}