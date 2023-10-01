namespace ProvaPub.Dtos;

public abstract class BaseListPaginated
{
    public int TotalCount { get; set; }
    public bool HasNext { get; set; }
}