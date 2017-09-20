using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Pex.Framework.Generated;
using System.Data;

namespace FFireManage.Utility.Tests
{
    [TestClass()]
    public class JsonHelperTests
    {
        [TestMethod()]
        public void ObjectToJSONTest()
        {
            string s;
            object boxc = (object)(default(char));
            // 用例测试1
            s = JsonHelper.ObjectToJSON((object)null);
            // 用例测试2
            object s0 = new object();
            s = JsonHelper.ObjectToJSON(s0);
            // 用例测试3          
            s = JsonHelper.ObjectToJSON(boxc);
            // 用例测试4
            PexSafeHelpers.AssignBoxedValue<char>(boxc, '!');
            s = JsonHelper.ObjectToJSON(boxc);
            // 用例测试5
            PexSafeHelpers.AssignBoxedValue<char>(boxc, ' ');
            // 用例测试6
            object box = (object)(default(Guid));
            s = JsonHelper.ObjectToJSON(box);
            // 用例测试7
            object boxd = (object)(default(double));
            s = JsonHelper.ObjectToJSON(boxd);
            // 用例测试8
            s = JsonHelper.ObjectToJSON("");
            // 用例测试9
            object boxf = (object)(default(float));
            s = JsonHelper.ObjectToJSON(boxf);
            // 用例测试10
             boxc = (object)(default(char));
            PexSafeHelpers.AssignBoxedValue<char>(boxc, '�');
            s = JsonHelper.ObjectToJSON(boxc);
            // 用例测试11
             box = (object)(default(DateTimeOffset));
            s = JsonHelper.ObjectToJSON(box);
            // 用例测试12
             box = (object)(default(decimal));
            s = JsonHelper.ObjectToJSON(box);
            // 用例测试13
             boxc = (object)(default(char));
            PexSafeHelpers.AssignBoxedValue<char>(boxc, '&');
            s = JsonHelper.ObjectToJSON(boxc);
            // 用例测试14
            object boxb = (object)(default(bool));
            s = JsonHelper.ObjectToJSON(boxb);
            // 用例测试15
            object[] os = new object[0];
            s = JsonHelper.ObjectToJSON((object)os);
            // 用例测试16
             box = (object)(default(DateTime));
            s = JsonHelper.ObjectToJSON(box);
            // 用例测试17
             boxb = (object)(default(bool));
            PexSafeHelpers.AssignBoxedValue<bool>(boxb, true);
            s = JsonHelper.ObjectToJSON(boxb);
            // 用例测试18
             os = new object[1];
            s = JsonHelper.ObjectToJSON((object)os);
            // 用例测试19
            //Uri uri;
            //uri = new Uri("%");
            //s = JsonHelper.ObjectToJSON((object)uri);
            // 用例测试20
            s = JsonHelper.ObjectToJSON("\0");
            // 用例测试21
            s = JsonHelper.ObjectToJSON("");
            // 用例测试22
            s = JsonHelper.ObjectToJSON("");
            // 用例测试23
             os = new object[1];
             s0 = new object();
            os[0] = s0;
            s = JsonHelper.ObjectToJSON((object)os);


        }

        [TestMethod()]
        public void DataTableToListTest()
        {
            List<Dictionary<string, object>> list;
            list = JsonHelper.DataTableToList((DataTable)null);
        }

        [TestMethod()]
        public void DataSetToDicTest()
        {
            Dictionary<string, List<Dictionary<string, object>>> dictionary;
            dictionary = JsonHelper.DataSetToDic((DataSet)null);
        }

        [TestMethod()]
        public void DataTableToJSONTest()
        {
            string s;
            s = JsonHelper.DataTableToJSON((DataTable)null);
        }

        [TestMethod()]
        public void JSONToObjectTest()
        {
            int i;
            //测试用例1
            i = JsonHelper.JSONToObject<int>((string)null);
            //测试用例2
            i = JsonHelper.JSONToObject<int>("");
            //测试用例3
            i = JsonHelper.JSONToObject<int>("\0");
            //测试用例4
            i = JsonHelper.JSONToObject<int>("-");
            //测试用例5
            i = JsonHelper.JSONToObject<int>("_");
            //测试用例6
            i = JsonHelper.JSONToObject<int>("y");
            //测试用例7
            i = JsonHelper.JSONToObject<int>("\0\0\0\0\0\0\0");
            //测试用例8
            i = JsonHelper.JSONToObject<int>("i\0");
            //测试用例9
            i = JsonHelper.JSONToObject<int>("\'");
        }

        [TestMethod()]
        public void TablesDataFromJSONTest()
        {
            Dictionary<string, List<Dictionary<string, object>>> dictionary;
            //测试用例1
            dictionary = JsonHelper.TablesDataFromJSON((string)null);
            //测试用例2
            dictionary = JsonHelper.TablesDataFromJSON("");
            //测试用例3
            dictionary = JsonHelper.TablesDataFromJSON("\0");
            //测试用例4
            dictionary = JsonHelper.TablesDataFromJSON("-");
            //测试用例5
            dictionary = JsonHelper.TablesDataFromJSON("_");
            //测试用例6
            dictionary = JsonHelper.TablesDataFromJSON("y");
            //测试用例7
            dictionary = JsonHelper.TablesDataFromJSON("\0\0\0\0\0\0\0");
            //测试用例8
            dictionary = JsonHelper.TablesDataFromJSON("i\0");
            //测试用例9
            dictionary = JsonHelper.TablesDataFromJSON("\'");

        }

        [TestMethod()]
        public void DataRowFromJSONTest()
        {
            Dictionary<string, object> dictionary;
            //测试用例1
            dictionary = JsonHelper.DataRowFromJSON((string)null);
            //测试用例2
            dictionary = JsonHelper.DataRowFromJSON("");
            //测试用例3
            dictionary = JsonHelper.DataRowFromJSON("\0");
            //测试用例4
            dictionary = JsonHelper.DataRowFromJSON("-");
            //测试用例5
            dictionary = JsonHelper.DataRowFromJSON("_");
            //测试用例6
            dictionary = JsonHelper.DataRowFromJSON("y");
            //测试用例7
            dictionary = JsonHelper.DataRowFromJSON("\0\0\0\0\0\0\0");
            //测试用例8
            dictionary = JsonHelper.DataRowFromJSON("i\0");
            //测试用例9
            dictionary = JsonHelper.DataRowFromJSON("\'");
        }
    }
}