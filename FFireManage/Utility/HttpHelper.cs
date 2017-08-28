using System;
using System.IO;
using System.Net;
using System.Text;

namespace FFireManage
{
    /// <summary>
    /// 类似于WepAPI接口Get、Post方式访问接口(json作为参数)
    /// </summary>
    public class HttpHelper
    {
        public static string HttpPost(string url,string postData, out bool iss)
        {
            iss = false;

            byte[] buffer = Encoding.UTF8.GetBytes(postData.ToString());

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
            webHeaderCollection.Add("Authorization", GlobeHelper.Instance.Token);


            httpWebRequest.Method = "POST";
            httpWebRequest.Headers = webHeaderCollection;
            httpWebRequest.ContentLength = buffer.Length;
            httpWebRequest.ContentType = "application/json; charset=utf-8";

            try
            {
                Stream newStream = httpWebRequest.GetRequestStream();

                newStream.Write(buffer, 0, buffer.Length);
                newStream.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                string responseContent = reader.ReadToEnd();

                iss = true;

                return responseContent;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string HttpGet(string url, out bool iss)
        {
            iss = false;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
            webHeaderCollection.Add("Authorization", GlobeHelper.Instance.Token);
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers = webHeaderCollection;
            httpWebRequest.ContentType = "application/json;charset=utf-8";

            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);

                string responseContent = streamReader.ReadToEnd();

                httpWebResponse.Close();
                streamReader.Close();

                iss = true;

                return responseContent;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
