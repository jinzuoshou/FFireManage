using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Model
{
    public class HotFeedback
    {
        public string id { get; set; }
        public string hot_id { get; set; }
        public int state { get; set; }
        public string description { get; set; }
        public int initiator{ get;set;}
        public string initiator_name { get; set; }
        public Nullable<int> examineUser { get; set; }
        public string examineUser_name { get; set; }
        public string createTime { get; set; }
        public string examineTime { get; set; }
        public string examineOption { get; set; }
        public Dictionary<string,object> MediaFileDict { get; set; }
        public List<MediaFile> mediaFiles { get; set; }
    }
}
