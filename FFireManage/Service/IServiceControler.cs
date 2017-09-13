using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFireManage.Service
{
    /// <summary>
    /// 服务事件参数
    /// </summary>
    public class ServiceEventArgs:EventArgs
    {
        public bool Succeed { get; set; }
        public string Content { get; set; }
        public string Message { get; set; }
        public object OriginObject { get; set; }
        public BaseResultInfo<object> ResponseObject { get; set; }
        public ServiceEventArgs(string content,bool isSucceed)
        {
            this.Content = content;
            this.Succeed = isSucceed;
        }
    }

    /// <summary>
    /// 业务服务公共接口
    /// </summary>
    public interface IServiceControler<T>
    {
        event EventHandler<ServiceEventArgs> QueryEvent;
        event EventHandler<ServiceEventArgs> AddEvent;
        event EventHandler<ServiceEventArgs> EditEvent;
        event EventHandler<ServiceEventArgs> DeleteEvent;
        event EventHandler<ServiceEventArgs> AddMediaEvent;
        event EventHandler<ServiceEventArgs> DeleteMediaEvent;

        void Get(Dictionary<string, object> parameterDict);
        void Add(T entity);
        void Edit(T entity);
        void Delete(Dictionary<string, object> parameterDict);
        void AddMedia(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict);
        void AddMedias(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict);
        void DeleteMedia(Dictionary<string, object> parameterDict);
    }

    /// <summary>
    /// 基础业务服务基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseServiceControler<T> : BaseService, IServiceControler<T>
    {
        protected string m_FullUrl = string.Empty;
        protected string m_Url = string.Empty;
        protected string m_Resource = string.Empty;

        public event EventHandler<ServiceEventArgs> AddEvent;
        public event EventHandler<ServiceEventArgs> DeleteEvent;
        public event EventHandler<ServiceEventArgs> EditEvent;
        public event EventHandler<ServiceEventArgs> QueryEvent;
        public event EventHandler<ServiceEventArgs> AddMediaEvent;
        public event EventHandler<ServiceEventArgs> DeleteMediaEvent;

        public BaseServiceControler()
        {
            this.m_FullUrl = string.Format("http://{0}:{1}/if/serviceController/action?", base.Server, base.Port);
            this.m_Url = string.Format("http://{0}:{1}", base.Server, base.Port);
            this.m_Resource = "/if/serviceController/action?";
        }

        protected void OnQueryEvent(object sender,ServiceEventArgs e)
        {
            if (QueryEvent != null)
                QueryEvent(sender, e);
        }

        protected void OnAddEvent(object sender, ServiceEventArgs e)
        {
            if (AddEvent != null)
                AddEvent(sender, e);
        }

        protected void OnEditEvent(object sender, ServiceEventArgs e)
        {
            if (EditEvent != null)
                EditEvent(sender, e);
        }

        protected void OnDeleteEvent(object sender, ServiceEventArgs e)
        {
            if (DeleteEvent != null)
                DeleteEvent(sender, e);
        }

        protected void OnAddMediaEvent(object sender, ServiceEventArgs e)
        {
            if (AddMediaEvent != null)
                AddMediaEvent(sender, e);
        }

        protected void OnDeleteMediaEvent(object sender, ServiceEventArgs e)
        {
            if (DeleteMediaEvent != null)
                DeleteMediaEvent(sender, e);
        }

        public virtual void Add(T entity){ }

        public virtual void Delete(Dictionary<string, object> parameterDict) { }

        public virtual void Edit(T entity) { }

        public virtual void Get(Dictionary<string, object> parameterDict) { }

        public virtual void AddMedia(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict){ }

        public virtual void AddMedias(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict){ }

        public virtual void DeleteMedia(Dictionary<string, object> parameterDict){ }

        protected void ExecutePost(
            Dictionary<string, object> parameterDict,
            EventHandler<ServiceEventArgs> callbackFunc,
            Dictionary<string, object> fileDict = null,
            Dictionary<string, string> headerDict = null,
            object entity = null)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                bool iss = false;
                string content = "";
                BaseResultInfo<object> result = null;
                try
                {
                    content = RestSharpHelper.HttpPost(this.m_Url, this.m_Resource, parameterDict, out iss, fileDict, headerDict, entity);
                    result = JsonHelper.JSONToObject<BaseResultInfo<object>>(content);
                    if(callbackFunc!=null)
                    {
                        if (result != null)
                            callbackFunc(this, new ServiceEventArgs(content, result.status == 10000)
                            {
                                OriginObject = entity,
                                Message = result.msg,
                                ResponseObject = result
                            });
                        else
                            callbackFunc(this, new ServiceEventArgs(content, false)
                            {
                                OriginObject = entity,
                                Message = "解析json(BaseResultInfo<object>)失败！",
                            });

                    }
                }
                catch(Exception ex)
                {
                    if (callbackFunc != null)
                    {
                        if (result != null)
                            callbackFunc(this, new ServiceEventArgs(content, result.status == 10000)
                            {
                                OriginObject = entity,
                                Message = string.Format("Response:{0}\r\n{1}\r\n{2}",content,ex.Message,ex.StackTrace),
                                ResponseObject = result
                            });
                        else
                            callbackFunc(this, new ServiceEventArgs(content, false)
                            {
                                OriginObject = entity,
                                Message = string.Format("Response:{0}\r\n{1}\r\n{2}", content, ex.Message, ex.StackTrace),
                            });

                    }
                }
            });
        }

        protected void ExecuteGet(Dictionary<string, object> parameterDict,
            EventHandler<ServiceEventArgs> callbackFunc,
            Dictionary<string, object> fileDict = null,
            Dictionary<string, string> headerDict = null,
            object entity = null)
        {
            Task task = Task.Factory.StartNew(() => 
            {
                bool iss = false;
                string content = "";
                try
                {
                    content = RestSharpHelper.HttpGet(this.m_Url, this.m_Resource, parameterDict, out iss, fileDict, headerDict, entity);
                    if (callbackFunc != null)
                        callbackFunc(this, new ServiceEventArgs(content, iss));

                }
                catch(Exception ex)
                {
                    if (callbackFunc != null)
                        callbackFunc(this, new ServiceEventArgs(content, iss) { Message = ex.Message + "\r\n" + ex.StackTrace });
                }
            });
        }

    }
}
