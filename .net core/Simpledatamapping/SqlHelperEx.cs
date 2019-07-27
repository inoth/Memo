using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Simpledatamapping.Attributes;

namespace Simpledatamapping
{
    public static class SqlHelperEx
    {

        public static T DataTableToSingleton<T>(this DataTable data) where T : class, new()
        => data.SingletonData().DicToEntity<T>();

        public static List<T> DataTableToEntityList<T>(this DataTable data) where T : class, new()
        => data.DataTableToDicList().DicListToEntityList<T>();

        public static List<Dictionary<string, object>> DataTableToDicList(this DataTable data)
        {
            var list = new List<Dictionary<string, object>>();
            if (data.Rows.Count <= 0)
            {
                return null;
            }
            for (int r = 0; r < data.Rows.Count; r++)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                for (int c = 0; c < data.Columns.Count; c++)
                {
                    dic.Add(data.Columns[c].ColumnName.ToLower(), data.Rows[r][c]);
                }
                list.Add(dic);
            }
            return list;
        }

        // 只取第一行数据
        public static Dictionary<string, object> SingletonData(this DataTable data)
        {
            var dic = new Dictionary<string, object>();
            if (data.Rows.Count <= 0)
            {
                return null;
            }
            if (data.Rows.Count > 1)
            {
                throw new Exception("Multiple data appear");
            }
            for (int c = 0; c < data.Columns.Count; c++)
            {
                dic.Add(data.Columns[c].ColumnName.ToLower(), data.Rows[0][c]);
            }
            return dic;
        }


        public static List<T> DicListToEntityList<T>(this List<Dictionary<string, object>> dic) where T : class, new()
        {
            if (dic == null)
            {
                return null;
            }
            Type type = typeof(T);
            // 查找自身特性
            object[] attrs = type.GetCustomAttributes(false);
            bool selfAru = false;
            foreach (var item in attrs)
            {
                if (item is InoTableAttribute classAttr)
                {
                    selfAru = true;
                    break;
                }
            }
            // 属性特性
            PropertyInfo[] props = type.GetProperties();
            InoFieldAttribute propAttr;
            List<T> list = new List<T>();
            foreach (var item in dic)
            {
                T entity = new T();
                foreach (var prop in props)
                {
                    propAttr = (InoFieldAttribute)Attribute.GetCustomAttribute(prop, typeof(InoFieldAttribute));
                    if (propAttr == null && !selfAru)
                    {
                        // 自身与属性都没有特性
                        continue;
                    }
                    if (item.TryGetValue((propAttr?.BindName ?? prop.Name).ToLower(), out object val))
                    {
                        prop.SetValue(entity, val.AutoChangeType(prop.PropertyType));
                    }
                }
                list.Add(entity);
            }
            return list;
        }

        public static T DicToEntity<T>(this Dictionary<string, object> dic) where T : class, new()
        {
            if (dic == null)
            {
                return null;
            }
            Type type = typeof(T);
            // 查找自身特性
            object[] attrs = type.GetCustomAttributes(false);
            bool selfAru = false;
            foreach (var item in attrs)
            {
                if (item is InoTableAttribute classAttr)
                {
                    selfAru = true;
                    break;
                }
            }
            // 属性特性
            PropertyInfo[] props = type.GetProperties();
            InoFieldAttribute propAttr;
            T entity = new T();
            foreach (var prop in props)
            {
                propAttr = (InoFieldAttribute)Attribute.GetCustomAttribute(prop, typeof(InoFieldAttribute));
                if (propAttr == null && !selfAru)
                {
                    // 自身与属性都没有特性
                    continue;
                }
                if (dic.TryGetValue((propAttr?.BindName ?? prop.Name).ToLower(), out object val))
                {
                    prop.SetValue(entity, val.AutoChangeType(prop.PropertyType));
                }
            }
            return entity;
        }

        public static object AutoChangeType(this object val, Type type)
        {
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (val.GetType() == typeof(DBNull) || val == null)
                    {
                        return null;
                    }
                    return Convert.ChangeType(val, Nullable.GetUnderlyingType(type));
                }
            }
            else if ((type.IsValueType || type.Equals(typeof(string))) && !(val ?? "null").Equals("null"))
            {
                return Convert.ChangeType(val, type);
            }
            return null;
        }
    }
}
