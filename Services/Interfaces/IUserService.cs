using ElectronicRealPropertyTaxUnisan.Models;

namespace ElectronicRealPropertyTaxUnisan.Services.Interfaces;

public interface IUserService
{
    Task<User> GetAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();
}
