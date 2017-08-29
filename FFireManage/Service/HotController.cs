using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFireManage.Utility;

namespace FFireManage.Service
{
    public class HotController:BaseServiceControler<Fire_Hot>
    {
        public EventHandler<ServiceEventArgs> FeedbackEvent;
        public EventHandler<ServiceEventArgs> AuditEvent;
        public EventHandler<ServiceEventArgs> GetDetailsEvent;

        private void OnFeedbackEvent(object sender,ServiceEventArgs e)
        {
            if (FeedbackEvent != null)
                FeedbackEvent(sender, e);
        }
        private void OnAuditEvent(object sender, ServiceEventArgs e)
        {
            if (AuditEvent != null)
                AuditEvent(sender, e);
        }
        private void OnGetDetailsEvent(object sender, ServiceEventArgs e)
        {
            if (GetDetailsEvent != null)
                GetDetailsEvent(sender, e);
        }

        public void Feedback(Fire_Hot hot)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4111003 },
                {"id",hot.id },
                {"initiator",hot.hotFeedback.initiator },
                {"description",hot.hotFeedback.description }
            };
            this.ExecutePost(parameterDict, OnFeedbackEvent, hot.hotFeedback.MediaFileDict, entity: hot);

        }

        public void Audit(Dictionary<string, object> parameterDict)
        {
            parameterDict.Add("f", 4112002);
            this.ExecutePost(parameterDict, OnAuditEvent);
        }

        public void GetDetails(Dictionary<string, object> parameterDict)
        {
            parameterDict.Add("f", 4110002);
            this.ExecuteGet(parameterDict, OnGetDetailsEvent);
        }

        /// <summary>
        /// 新增热点
        /// </summary>
        /// <param name="entity">热点实体</param>
        public override void Add(Fire_Hot entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4111001);
                }
                this.ExecutePost(parameterDict, OnAddEvent,entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 获取热点列表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if(!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4110001);
                }
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 编辑热点
        /// </summary>
        /// <param name="entity">热点实体</param>
        public override void Edit(Fire_Hot entity)
        {
            if(entity!=null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if(!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4112001);
                }
                this.ExecutePost(parameterDict, OnEditEvent, entity: entity);
            }
        }

        /// <summary>
        /// 删除热点
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if(!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4113001);
                }
            }
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

        public void Delete(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4133001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }
    }
}
