//===================================================
//  Copyright @ fallstar0@qq.com 2016
//  作者：Fallstar
//  时间：2016-06-15 11:32:58
//  说明：一些数据库（SQL）相关的帮助方法
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS.DBAccess
{
    /// <summary>
    /// 一些数据库（SQL）相关的帮助方法
    /// </summary>
    public static class DbTool
    {
        /// <summary>
        /// 将传入列表转换为SQL查询用的 in或者= 语句，如xx=1, xx in (1,2,3) ,xx='1' , xx in ('xx','yy','zz')。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldName">要生成的字段</param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ToSqlParams<T>(string fieldName, IEnumerable<T> values)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException(nameof(fieldName));
            if (values == null || values.Count() < 1)
                throw new ArgumentException(nameof(values));

            var sb = new StringBuilder();
            sb.Append(fieldName);
            var c = values.Count();
            var t = typeof(T);
            //如果只有一条记录，直接用=
            if (c == 1)
            {
                sb.Append("=");
                if (t.IsValueType)
                    sb.Append(values.First().ToString());
                else
                    sb.AppendFormat("'{0}'", values.First().ToString());
                return sb.ToString();
            }
            //多条记录的时候，组装 in
            sb.Append(" in (");
            foreach (var item in values)
            {
                if (t.IsValueType)
                    sb.Append(item.ToString() + ",");
                else
                    sb.AppendFormat("'{0}',", item.ToString());
            }

            return sb.ToString().TrimEnd(',') + ")";
        }

        #region 连接字符串

        /// <summary>
        /// 创建Oracle格式的连接字符串
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="dbName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string CreateOracleConnectionString(string address, ushort port, string dbName, string userName, string password)
        {
            string connString = string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};Pooling=false",
             address, port, dbName, userName, password);
            return connString;
        }
        #endregion
    }
}
