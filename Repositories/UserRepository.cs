using ElectronicRealPropertyTaxUnisan.Repositories.Interfaces;
using ElectronicRealPropertyTaxUnisan.Models;
using System.Data;
using Dapper;

namespace ElectronicRealPropertyTaxUnisan.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;

    public UserRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        const string sql = @"
                SELECT * FROM Users 
                WHERE Email = @Email";
        return await _connection.QuerySingleOrDefaultAsync<User>(sql, new { Email = email });
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Users";
        return await _connection.QueryAsync<User>(sql);
    }

    public async Task<int> CreateAsync(User user)
    {
        const string sql = @"
                INSERT INTO Users (Email, PasswordHash, FirstName, LastName, DateOfBirth, IsActive, CreatedAt, UpdatedAt, LastLogin)
                VALUES (@Email, @PasswordHash, @FirstName, @LastName, @DateOfBirth, @IsActive, @CreatedAt, @UpdatedAt, @LastLogin)
                RETURNING Id";

        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        return await _connection.ExecuteScalarAsync<int>(sql, user);
    }

    public async Task<bool> UpdateAsync(User user)
    {
        const string sql = @"
                UPDATE Users 
                SET PasswordHash = @PasswordHash, 
                    FirstName = @FirstName, 
                    LastName = @LastName, 
                    DateOfBirth = @DateOfBirth, 
                    IsActive = @IsActive, 
                    UpdatedAt = @UpdatedAt
                WHERE Email = @Email";

        user.UpdatedAt = DateTime.UtcNow;
        int affectedRows = await _connection.ExecuteAsync(sql, user);
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(string email)
    {
        const string sql = "DELETE FROM Users WHERE Email = @Email";
        int affectedRows = await _connection.ExecuteAsync(sql, new { Email = email });
        return affectedRows > 0;
    }

    public async Task<bool> UpdateLastLoginAsync(string email)
    {
        const string sql = @"
                UPDATE Users 
                SET LastLogin = @LastLogin
                WHERE Email = @Email";

        int affectedRows = await _connection.ExecuteAsync(sql, new { Email = email, LastLogin = DateTime.UtcNow });
        return affectedRows > 0;
    }
}
