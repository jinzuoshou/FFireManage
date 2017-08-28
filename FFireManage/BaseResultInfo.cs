using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
    public class BaseResultInfo<T>
    {
        public int status { get; set; }
        public string msg { get; set; }
        public T obj { get; set; }
    }
}
