using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Model
{
    public class GetListResultInfo<T>
    {
        public int total { get; set; }
        public int page { get; set; }
        public List<T> rows { get; set; }
    }
}
