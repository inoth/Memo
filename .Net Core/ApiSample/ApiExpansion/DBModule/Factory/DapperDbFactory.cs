using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ApiExpansion.DBModule.Factory
{
    public class DapperDbFactory : IDapperDbFactory
    {
        private readonly string _constr;
        public DapperDbFactory(IConfiguration config)
        {
            this._constr = config.GetSection("dbStr:dbClient").Value;
        }
        public IDbConnection Create() => new MySqlConnection(this._constr);
    }
}