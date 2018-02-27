//===================================================
//  Copyright @  fallstar0@qq.com 2017
//  作者：Fallstar
//  时间：2017-02-28 11:23:57
//  说明：数据库信息访问接口定义
//===================================================
using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.DbExtractor
{
    /// <summary>
    /// 数据库信息访问接口定义，用于抽取基本基本信息
    /// </summary>
    public interface IDbExtractor
    {
        /// <summary>
        /// 获取数据库的所有表的信息
        /// </summary>
        /// <returns></returns>
        List<DbTableInfo> GetAllTables();
        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <param name="tableName">数据表的名称</param>
        /// <returns></returns>
        List<DbFieldInfo> GetAllColumns(string tableName);
        /// <summary>
        /// 类型转换，通过字段信息转换为 C# 使用的数据类型
        /// </summary>
        /// <param name="info">字段信息</param>
        /// <returns></returns>
        string ConvertDataType(DbFieldInfo info);
    }
}
