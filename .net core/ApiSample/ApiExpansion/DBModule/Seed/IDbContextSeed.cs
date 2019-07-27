using Microsoft.EntityFrameworkCore;

namespace ApiExpansion.DBModule.Seed
{
    public interface IDbContextSeed
    {
        void Seed(ModelBuilder builder);
    }
}