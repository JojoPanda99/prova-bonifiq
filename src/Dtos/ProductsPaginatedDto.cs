using ProvaPub.Models;

namespace ProvaPub.Dtos;

public class ProductsPaginatedDto : BaseListPaginated
{
    public List<Product> Products { get; set; }
}