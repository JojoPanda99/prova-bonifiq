using Bogus;
using Bogus.DataSets;
using Moq.AutoMock;
using ProvaPub.Models;
using ProvaPub.Services;

namespace ProvaPubTests.Fixtures;

[CollectionDefinition(nameof(CustomerColletion))]
public class CustomerColletion : ICollectionFixture<CustomerTestsFixture>
{
}

public class CustomerTestsFixture : IDisposable
{
    public AutoMocker Mocker;
    public CustomerService CustomerService;
    public List<Customer> Customers { get; set; }

    public CustomerTestsFixture()
    {
        Customers = new List<Customer>();
        PopulateCustomers();
    }

    public CustomerService GetCustomerService()
    {
        Mocker = new AutoMocker();
        CustomerService = Mocker.CreateInstance<CustomerService>();

        return CustomerService;
    }

    public List<Customer> GetCustomerListPaginated(int page, int size)
    {
        return Customers.Skip(page * size).Take(size).ToList();
    }

    public Customer GenerateCustomer()
    {
        var gender = new Faker().PickRandom<Name.Gender>();
        var customer = new Faker<Customer>()
            .CustomInstantiator(f => new Customer
            {
                Id = f.UniqueIndex + 1,
                Name = f.Name.FullName(gender),
                Orders = new List<Order>()
            });

        return customer;
    }

    private void PopulateCustomers()
    {
        for (int i = 0; i < 20; i++)
        {
            Customers.Add(GenerateCustomer());
        }
    }

    public void Dispose()
    {
    }
}