using Bogus;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Domain.Enums;

namespace Pacagroup.Ecommerce.Persistence.Mocks;

public class DiscountGetAllWithPaginationAsyncBogusConfig : Faker<Discount>
{
    public DiscountGetAllWithPaginationAsyncBogusConfig()
    {
        RuleFor(p => p.Id, f => f.IndexFaker + 1); //Se suma 1 para que inicie desde id número 1
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
        RuleFor(p => p.Percent, f => f.Random.Int(70, 90));        
        RuleFor(u => u.Status, f => f.PickRandom<DiscountStatus>());
    }
}
