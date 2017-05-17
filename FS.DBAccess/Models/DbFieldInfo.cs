//===================================================
//  Copyright @  Thpower.com 2017
//  作者：Fallstar
//  时间：2017-02-28 11:31:32
//  说明：表的字段
//===================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.DBAccess
{
    /// <summary>
    /// 表的字段
    /// </summary>
    public class DbFieldInfo
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public DbFieldInfo()
        {
            FieldName = string.Empty;
            Description = string.Empty;
        }
        /// <summary>
        /// 仅用于在UI上显示名称的。
        /// </summary>
        public string DisplayName { get { return FieldName; } }

        /// <summary>
        /// 字段名称
        /// </summary>
        [DisplayName("字段名称"), Description("该字段在数据库存放的名称（列名）")]
        public string FieldName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述"), Description("描述")]
        public string Description { get; set; }

        private string _DataType = "string";
        /// <summary>
        /// 系统数据类型，如 int
        /// </summary>
        [DisplayName("系统类型"), Description("与其对应的系统类型")]
        public string DataType
        {
            get { return _DataType; }
            set
            {
                _DataType = value;
                //if (string.IsNullOrEmpty(_DBType))
                // _DBType = TypeConvertHelper.CsharpType2SqlTypeStr(value);
            }
        }

        /// <summary>
        /// 数据库里面存放的类型。
        /// </summary>
        [DisplayName("字段类型"), Description("在数据库里面存放的类型")]
        public string FieldType { get; set; }

        /// <summary>
        /// 代表小数位精度。
        /// </summary>
        [DisplayName("小数位数"), Description("代表小数位精度")]
        public byte FieldScale { get; set; }
        /// <summary>
        /// 数据精度，仅数字类型有效，总共多少位数字（10进制）。
        /// 在MySql里面代表了字段长度
        /// </summary>
        [DisplayName("数据精度"), Description("数据精度，总共多少位数字（10进制）")]
        public ushort FieldPrecision { get; set; }

        /// <summary>
        /// 可空
        /// </summary>
        [DisplayName("可空"), Description("是否可空")]
        public bool IsNullable { get; set; }
        /// <summary>
        /// 是否为主键字段
        /// </summary>
        [DisplayName("主键"), Description("是否为主键字段")]
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 【未用上】该字段是否自增
        /// </summary>
        public bool Increment { get; set; }


        /// <summary>
        /// 获取数据类型，如果可空，返回对应字段如 int? ,DateTime?
        /// </summary>
        public string DataTypeEx
        {
            get
            {
                if (DataType != null && DataType.EndsWith("?")) return DataType;
                var ext = (IsNullable && DataType != "string" && DataType != "byte[]") ? "?" : "";
                return DataType + ext;
            }
        }

        /// <summary>
        /// 该字段在数据库中是否可空。
        /// </summary>
        public bool CanNullInDB { get { return !IsIdentity && (IsNullable || DataType == "string" || DataType == "byte[]"); } }
    }
}
