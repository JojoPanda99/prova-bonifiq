using ProvaPub.Interfaces.Services;

namespace ProvaPub.Services;

public class RandomService : IRandomService
{
    private int seed { get; }

    public RandomService()
    {
        seed = Guid.NewGuid().GetHashCode();
    }

    public Task<int> GetRandom()
    {
        return Task.FromResult(new Random(seed).Next(100));
    }
}