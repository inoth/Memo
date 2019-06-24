using System.Collections.Generic;
using ApiExpansion.DBModule.Factory;
using ApiExpansion.DBModule.Mapper;
using ApiExpansion.DBModule.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiExpansion.DBModule.Context
{
    public class ApplicationDbContextOptions
    {
        public readonly DbContextOptions<ApplicationDbContext> _option;
        public readonly IEnumerable<IEntityTypeMapper> _mappers;
        public readonly IDbContextSeed _seed;
        public ApplicationDbContextOptions(DbContextOptions<ApplicationDbContext> option, IEnumerable<IEntityTypeMapper> mappers, IDbContextSeed seed)
        {
            this._option = option;
            this._mappers = mappers;
            this._seed = seed;
        }
        public ApplicationDbContextOptions(DbContextOptions<ApplicationDbContext> option, IEnumerable<IEntityTypeMapper> mappers) : this(option, mappers, null) { }
    }
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContextOptions _option;
        public ApplicationDbContext(ApplicationDbContextOptions options) : base(options._option) => this._option = options;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var mapping in this._option._mappers)
            {
                mapping.Mapping(modelBuilder);
            }
            this._option._seed?.Seed(modelBuilder);
        }
    }
    public static class ApplicationDbContextExtensions
    {
        public static DbSet<TEntity> DatabaseSet<TEntity>(this ApplicationDbContext context)
        where TEntity : class, new() => context.Set<TEntity>();

        public static IServiceCollection InitDBOption(this IServiceCollection services, string constr)
        {
            services.AddSingleton<IDapperDbFactory, DapperDbFactory>();
            services.AddSingleton(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySQL(constr).Options);
            services.AddSingleton<ApplicationDbContextOptions>();
            services.AddSingleton<IApplicationDbContextFactory, ApplicationDbContextFactory>();
            services.AddDbContext<ApplicationDbContext>();
            return services;
        }
    }
}