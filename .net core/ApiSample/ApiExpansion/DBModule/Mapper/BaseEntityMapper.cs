using Microsoft.EntityFrameworkCore;

namespace ApiExpansion.DBModule.Mapper
{
    public abstract class BaseEntityMapper : IEntityTypeMapper
    {
        public void Mapping(ModelBuilder builder)
        {
            InternalMap(builder);
        }
        protected abstract void InternalMap(ModelBuilder builder);
    }
}