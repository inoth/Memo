using System.Data;

namespace ApiExpansion.DBModule.Factory
{
    public interface IDapperDbFactory
    {
        IDbConnection Create();
    }
}