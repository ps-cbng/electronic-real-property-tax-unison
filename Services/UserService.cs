using ElectronicRealPropertyTaxUnisan.Services.Interfaces;
using ElectronicRealPropertyTaxUnisan.Models;
using ElectronicRealPropertyTaxUnisan.Repositories.Interfaces;

namespace ElectronicRealPropertyTaxUnisan.Services;
public class UserService : IUserService
{
    private IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }
}
