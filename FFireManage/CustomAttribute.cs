using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
    // <summary>
    /// 自定义特性 属性或者类可用  支持继承
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public class CustomAttribute:Attribute
    {
        private string tableName;
        /// <summary>
        /// 实体实际对应的表名
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private string columnName;
        /// <summary>
        /// 中文列名
        /// </summary>
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        private bool isRequired = true;

        /// <summary>
        /// 是否要被参数化
        /// </summary>
        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }

        private bool isEnumValue = false;

        /// <summary>
        /// 是否是枚举值
        /// </summary>
        public bool IsEnumValue
        {
            get { return isEnumValue; }
            set { isEnumValue = value; }
        }

        private Type enumType;

        /// <summary>
        /// 类型（枚举）
        /// </summary>
        public Type EnumType
        {
            get
            {
                return enumType;
            }

            set
            {
                enumType = value;
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { this.description = value; }
        }

    }
}
