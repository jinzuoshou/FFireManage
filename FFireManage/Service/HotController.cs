using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
