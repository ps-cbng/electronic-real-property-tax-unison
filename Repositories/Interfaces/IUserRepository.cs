using ElectronicRealPropertyTaxUnisan.Models;

namespace ElectronicRealPropertyTaxUnisan.Repositories.Interfaces;
public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();
    Task<int> CreateAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(string email);
    Task<bool> UpdateLastLoginAsync(string email);
}
