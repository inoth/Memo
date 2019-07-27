using ApiExpansion.DBModule.Context;

namespace ApiExpansion.DBModule.Factory
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }
}