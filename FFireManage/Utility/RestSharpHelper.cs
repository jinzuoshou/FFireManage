using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Utility
{
    /// <summary>
    /// 基于RestSharpHelper实现的http帮助类
    /// </summary>
    public static class RestSharpHelper
    {
        /// <summary>
        /// http Get方式请求数据（普通传参方式）
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="resource">请求资源</param>
        /// <param name="parameterDict">http参数组成的字典</param>
        /// <param name="iss">是否执行成功</param>
        /// <param name="fileDict">文件组成的字典（值最好为文件路径或者文件二进制流）</param>
        /// <param name="headerDict">http头组成的字典</param>
        /// <param name="entity">对象实体（entity不为null时，所有public类型都会被当作参数传递：不推荐）</param>
        /// <returns></returns>
        public static string HttpGet(string url,string resource, Dictionary<string, object> parameterDict, out bool iss, Dictionary<string, object> fileDict = null,Dictionary < string,string> headerDict=null, object entity = null)
        {
            iss = false;
            try
            {
                //参考：https://github.com/restsharp/RestSharp/wiki
                RestClient client = new RestClient(new Uri(url));
                var request = new RestRequest(resource, Method.GET);
                if (headerDict != null)
                {
                    foreach (KeyValuePair<string, string> info in headerDict)
                    {
                        request.AddHeader(info.Key, info.Value);
                    }
                }
                if (fileDict != null)
                {
                    foreach (KeyValuePair<string, object> info in fileDict)
                    {
                        if (info.Value is string)
                            request.AddFile(info.Key, info.Value.ToString());
                        else if (info.Value is byte[])
                        {
                            request.AddFile(info.Key, (byte[])info.Value, info.Key);
                        }
                    }
                }
                if (parameterDict != null)
                {
                    foreach (KeyValuePair<string, object> info in parameterDict)
                    {
                        request.AddParameter(info.Key, info.Value);
                    }
                }
                
                client.Encoding = Encoding.GetEncoding("utf-8");
                IRestResponse response = client.Execute(request);
                response.ContentEncoding = "utf-8";
                var cookies = response.Cookies;
                var content = response.Content; // raw content as string
                iss = true;
                return content;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// htpp post方式请求数据（普通传参方式）
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="resource">请求资源</param>
        /// <param name="parameterDict">http参数组成的字典</param>
        /// <param name="iss">是否执行成功</param>
        /// <param name="fileDict">文件组成的字典（值最好为文件路径或者文件二进制流）</param>
        /// <param name="headerDict">http头组成的字典</param>
        /// <param name="entity">对象实体（entity不为null时，所有public类型都会被当作参数传递：不推荐）</param>
        /// <returns></returns>
        public static string HttpPost(string url, string resource, Dictionary<string, object> parameterDict, out bool iss, Dictionary<string, object> fileDict = null,Dictionary < string, string> headerDict=null, object entity = null)
        {
            iss = false;
            try
            {
                //参考：https://github.com/restsharp/RestSharp/wiki
                RestClient client = new RestClient(new Uri(url));
                var request = new RestRequest(resource, Method.POST);
                if (parameterDict != null)
                {
                    foreach (KeyValuePair<string, object> info in parameterDict)
                    {
                        request.AddParameter(info.Key, info.Value);
                    }
                }
                if (fileDict != null)
                {
                    foreach (KeyValuePair<string, object> info in fileDict)
                    {
                        if (info.Value is string)
                            request.AddFile(info.Key, info.Value.ToString());
                        else if (info.Value is byte[])
                        {
                            request.AddFile(info.Key, (byte[])info.Value, info.Key);
                        }
                    }
                }
                if (headerDict != null)
                {
                    foreach (KeyValuePair<string, string> info in headerDict)
                    {
                        request.AddHeader(info.Key, info.Value);
                    }
                }
                
                if(entity != null)
                {
                    request.AddObject(entity);
                }
                client.Encoding = Encoding.GetEncoding("utf-8");
                IRestResponse response = client.Execute(request);
                response.ContentEncoding = "utf-8";
                var cookies = response.Cookies;
                var content = response.Content; // raw content as string
                iss = true;
                return content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
