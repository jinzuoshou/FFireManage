using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
    /// <summary>
    /// 行政区信息（代码和名称）
    /// </summary>
    public class AreaCodeInfo
    {
        private string code;
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
