//===================================================
//  作者：Fallstar
//  时间：2017-05-15 11:10:12
//  说明：抽取逻辑
//===================================================
using FS.DBAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.DbExtractor;

namespace FS.DbModelTool
{
    /// <summary>
    /// 抽取逻辑
    /// </summary>
    internal class ExtactLogic
    {
        #region 字段与属性
        /// <summary>
        /// 可以使用的数据库连接名称
        /// </summary>
        public List<string> DbNames { get; private set; }
        /// <summary>
        /// 当前使用哪个数据库连接(名称)
        /// </summary>
        public string CurrentDbName { get; set; }
        /// <summary>
        /// 抽取器
        /// </summary>
        private IDbExtractor extractor = null;

        /// <summary>
        /// 所有表格信息
        /// </summary>
        public List<DbTableInfo> TableInfos { get; private set; }
        #endregion

        #region 基本
        /// <summary>
        /// 获取数据库连接名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetDbConnectionNames()
        {
            var list = new List<string>();
            var cfg = ConfigurationManager.ConnectionStrings;
            if (cfg == null) return list;
            for (int i = 0; i < cfg.Count; i++)
            {
                var item = cfg[i];
                list.Add(item.Name);
            }
            DbNames = list;
            return list;
        }

        /// <summary>
        /// 设置数据库连接，并创建抽取器
        /// </summary>
        /// <param name="dbConnectionName"></param>
        /// <returns></returns>
        public ResultEntity<bool> SetDbConnection(string dbConnectionName)
        {
            var result = new ResultEntity<bool>();
            if (string.IsNullOrEmpty(dbConnectionName))
                return result.SetFail("Parameter null : " + nameof(dbConnectionName));
            CurrentDbName = dbConnectionName;
            try
            {
                extractor = ExtractorFactory.Create(dbConnectionName);
            }
            catch (Exception ex)
            {
                result.SetFail(ex);
            }
            return result;
        }

        /// <summary>
        /// 通过连接字符串名称，来获取该数据库所有表的信息
        /// </summary>
        /// <param name="dbConnectionName"></param>
        /// <returns></returns>
        public ResultEntity<List<DbTableInfo>> GetTableNames()
        {
            var result = new ResultEntity<List<DbTableInfo>>();
            if (extractor == null)
                return result.SetFail("Please call SetDbConnection before this!");

            try
            {
                var tables = extractor.GetAllTables();
                tables = tables.OrderBy(x => x.TableName).ToList();
                result.Result = tables;
                TableInfos = tables;
            }
            catch (Exception ex)
            {
                result.SetFail(ex);
            }
            return result;
        }

        /// <summary>
        /// 填充实体里面的表字段信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ResultEntity GetTableFields(DbTableInfo info)
        {
            var result = new ResultEntity();
            try
            {
                var list = extractor.GetAllColumns(info.TableName);
                info.Fileds = list;
            }
            catch (Exception ex)
            {
                result.SetFail(ex);
            }
            return result;
        }
        #endregion

    }
}
