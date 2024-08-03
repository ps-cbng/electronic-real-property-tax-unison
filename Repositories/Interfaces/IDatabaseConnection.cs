using System.Data;

namespace ElectronicRealPropertyTaxUnisan.Repositories.Interfaces;
public interface IDatabaseConnection
{
    IDbConnection CreateConnection();
}
