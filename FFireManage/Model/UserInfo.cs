using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage
{
    public class UserInfo
    { 
        public int id { get; set; }
        public string account { get; set; }
        public int accountType { get; set; }
        public int deviceType { get; set; }
        public string deviceName { get; set; }
        public string deviceId { get; set; }
        public string pac { get; set; }
        public int competence { get; set; }
        public string headFilename { get; set; }
        public string iosToken { get; set; }
        public string jid { get; set; }
        public int online { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string voipAccount { get; set; }
        public string voipPassword { get; set; }
        public string subscriber { get; set; }
        public string imei { get; set; }
        public string token{get;set;}
        public string headPortrait { set; get; }
    }
}
