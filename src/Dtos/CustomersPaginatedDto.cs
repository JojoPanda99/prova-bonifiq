using ProvaPub.Models;

namespace ProvaPub.Dtos;

public class CustomersPaginatedDto : BaseListPaginated
{
    public List<Customer> Customers { get; set; }
}