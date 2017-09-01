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
        public string code
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
