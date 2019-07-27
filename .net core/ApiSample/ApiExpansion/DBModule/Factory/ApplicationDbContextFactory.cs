using ApiExpansion.DBModule.Context;

namespace ApiExpansion.DBModule.Factory
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        ApplicationDbContextOptions options;
        public ApplicationDbContextFactory(ApplicationDbContextOptions options) => this.options = options;
        public ApplicationDbContext Create() => new ApplicationDbContext(this.options);
    }
}