//===================================================
//  作者：Fallstar
//  时间：2017-05-12 15:35:28
//  说明：主要管理器
//===================================================
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FS.DBAccess;
using FS.DbExtractor;
using System.Windows.Forms;

namespace FS.CodeTool
{
    /// <summary>
    /// 主要管理器
    /// </summary>
    internal class MainManager
    {
        /// <summary>
        /// 抽取逻辑类
        /// </summary>
        public static ExtactLogic Logic = new ExtactLogic();
        /// <summary>
        /// 获取数据库连接名称
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDbConnectionNames()
        {
            return Logic.GetDbConnectionNames();
        }

        /// <summary>
        /// 通过连接字符串名称，来获取该数据库所有表的信息
        /// </summary>
        /// <param name="dbConnectionName"></param>
        /// <returns></returns>
        public static ResultEntity<List<DbTableInfo>> GetTableNames(string dbConnectionName)
        {
            return Logic.GetTableNames();
        }

        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logAction"></param>
        public static void GenFiles(GenFileModel model, Action<string> logAction)
        {
            try
            {
                if (!Directory.Exists(model.FilePath))
                    Directory.CreateDirectory(model.FilePath);
                var sb = new StringBuilder();
                var index = 0;
                var allcount = model.Tables.Count;
                foreach (var table in model.Tables)
                {
                    index++;
                    var ret = Logic.GetTableFields(table);
                    if (!ret.IsSuccess)
                    {
                        logAction(table.TableName + "：" + ret.ReplyMsg);
                        continue;
                    }
                    sb.Clear();
                    sb.AppendLine("using System;");
                    sb.AppendLine("using System.Collections.Generic;");
                    sb.AppendLine("using System.Linq;");
                    sb.AppendLine("");
                    sb.AppendLine("namespace " + model.NameSpace);
                    sb.AppendLine("{");
                    sb.AppendLine("    /// <summary>");
                    sb.AppendLine("    /// " + table.Description ?? table.TableName);
                    sb.AppendLine("    /// </summary>");
                    sb.AppendLine("    public partial class " + table.TableName);
                    sb.AppendLine("    {");
                    foreach (var field in table.Fileds)
                    {
                        sb.AppendLine("        /// <summary>");
                        sb.AppendLine("        /// " + field.Description);
                        sb.AppendLine("        /// </summary>");
                        sb.AppendLine("        public " + field.DataTypeEx + " " + field.FieldName + " { get; set; }");
                    }
                    sb.AppendLine("    }");
                    sb.AppendLine("}");
                    File.WriteAllText(Path.Combine(model.FilePath, table.TableName + ".cs"), sb.ToString(), Encoding.UTF8);
                    logAction(string.Format("[{0}/{1}]生成文件：{2}", index, allcount, table.TableName + ".cs"));
                }
                logAction("已经生成所有文件~");
            }
            catch (Exception ex)
            {
                logAction(ex.Message + ex.StackTrace);
            }

        }
    }
}
