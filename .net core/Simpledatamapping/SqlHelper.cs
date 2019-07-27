using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Simpledatamapping
{
    public static class SqlHelper
    {
        private static readonly string constr = "";

         public static int ExecuteNonQuery(string sql, CommandType cmdType = CommandType.Text, params OracleParameter[] pms)
        {
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    cmd.CommandType = cmdType;
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params OracleParameter[] pms)
        {
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, CommandType cmdType = CommandType.Text, params OracleParameter[] pms)
        {
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    cmd.CommandType = cmdType;
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static object ExecuteScalar(string sql, params OracleParameter[] pms)
        {
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static OracleDataReader ExecuteReader(string sql, CommandType cmdType = CommandType.Text, params OracleParameter[] pms)
        {
            OracleConnection con = new OracleConnection(constr);
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                con.Open();
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                cmd.CommandType = cmdType;
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        public static OracleDataReader ExecuteReader(string sql, params OracleParameter[] pms)
        {
            OracleConnection con = new OracleConnection(constr);
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                con.Open();
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static DataTable OracleDataAdapter(string sql, CommandType cmdType = CommandType.Text, params OracleParameter[] pms)
        {
            DataTable td = new DataTable();
            using (OracleDataAdapter adapter = new OracleDataAdapter(sql, constr))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.CommandType = cmdType;
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(td);
            }
            return td;
        }

        public static DataTable OracleDataAdapter(string sql, params OracleParameter[] pms)
        {
            DataTable td = new DataTable();
            using (OracleDataAdapter adapter = new OracleDataAdapter(sql, constr))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(td);
            }
            return td;
        }

        public static T SqlQuerySingleton<T>(string sql, params OracleParameter[] pms) where T : class, new()
        => OracleDataAdapter(sql, pms).DataTableToSingleton<T>();        
        public static List<T> SqlQueryList<T>(string sql, params OracleParameter[] pms) where T : class, new()
        => OracleDataAdapter(sql, pms).DataTableToEntityList<T>();
        public static List<T> SqlQueryList<T>(string sql, CommandType cmdType = CommandType.Text, params OracleParameter[] pms) where T : class, new()
        => OracleDataAdapter(sql, cmdType, pms).DataTableToEntityList<T>();
        public static List<Dictionary<string, object>> SqlQueryByDicList(string sql, params OracleParameter[] pms)
        => OracleDataAdapter(sql, pms).DataTableToDicList();
        public static List<Dictionary<string, object>> SqlQueryByDicList(string sql, CommandType cmdType = CommandType.Text, params OracleParameter[] pms)
        => OracleDataAdapter(sql, cmdType, pms).DataTableToDicList();
    }
}