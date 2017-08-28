using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace FFireManage
{
    /// <summary>
    /// 原始WebService接口通过Get、Post访问接口帮助类
    /// </summary>
    public class HttpHelper2
    {
        public static string HttpGet(string Url, string getData, out bool iss)
        {
            iss = false;
            
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url + getData);
            
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "text/xml; charset=utf-8";

            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                Stream responseStream = httpWebResponse.GetResponseStream();

                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);

                string retstring = streamReader.ReadToEnd();

                streamReader.Close();
                responseStream.Close();

                iss = true;

                return retstring;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string HttpPost(string url, string postData, out bool iss)
        {
            iss = false;

            byte[] buffer = Encoding.UTF8.GetBytes(postData.ToString());
            

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = buffer.Length;
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Accept =
               "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";


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
    }
}
