using Microsoft.EntityFrameworkCore;

namespace ApiExpansion.DBModule.Mapper
{
    public interface IEntityTypeMapper
    {
        void Mapping(ModelBuilder builder);
    }
}