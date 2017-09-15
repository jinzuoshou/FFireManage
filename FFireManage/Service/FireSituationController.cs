using FFireManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFireManage.Utility;

namespace FFireManage.Service
{
    public class FireSituationController : BaseServiceControler<FireSituation>
    {
        /// <summary>
        /// 新增火情
        /// </summary>
        /// <param name="entity"></param>
        public override void Add(FireSituation entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if(!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4191001);
                this.ExecutePost(parameterDict, OnAddEvent, entity.MediaFileDict, entity: entity);
            }
        }

        /// <summary>
        ///删除火情
        /// </summary>
        /// <param name="parameterDict"></param>
        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4193001);
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 编辑火情
        /// </summary>
        /// <param name="entity"></param>
        public override void Edit(FireSituation entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4192001);
                this.ExecutePost(parameterDict, OnEditEvent, entity.MediaFileDict);
            }
        }

        /// <summary>
        /// 获取火情列表
        /// </summary>
        /// <param name="parameterDict"></param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4190001);
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增火情媒体文件
        /// </summary>
        /// <param name="parameterDict">新增媒体参数字典</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        public override void AddMedia(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4190001);
                this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
            }
        }

        /// <summary>
        /// 新增火情媒体文件
        /// </summary>
        /// <param name="id">火情id</param>
        /// <param name="fileDict"></param>
        public void AddMedia(string id,Dictionary<string,object> fileDict)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4190001},
                {"id",id }
            };
            this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
        }

        /// <summary>
        /// 删除火情媒体文件
        /// </summary>
        /// <param name="parameterDict"></param>
        public override void DeleteMedia(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4193001);
                this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
            }
        }

        /// <summary>
        /// 删除媒体文件
        /// </summary>
        /// <param name="id">媒体id</param>
        public void DeleteMedia(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4193001},
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
        }
    }
}
