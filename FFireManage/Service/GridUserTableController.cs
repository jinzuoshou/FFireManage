// <copyright file="GridUserTableController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-09-15 </date>
// <summary>网格人员管理表业务服务类</summary>
// <modify>
// 修改人：
// 修改时间：
// 修改描述：
// 版本：1.0
//</modify>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFireManage.Model;
using FFireManage.Utility;

namespace FFireManage.Service
{
    /// <summary>
    /// 网格人员管理表业务服务
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-09-15
    /// 修改人：
    /// 修改日期：
    /// 修改备注：无
    /// 版本：1.0
    public class GridUserTableController:BaseServiceControler<GridUserTableInfo>
    {
        /// <summary>
        /// 获取网格人员管理表列表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4290001);
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增网格人员管理表
        /// </summary>
        /// <param name="entity">网格人员管理表</param>
        public override void Add(GridUserTableInfo entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4291001);
                }
                this.ExecutePost(parameterDict, OnAddEvent, entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑人员网格管理表
        /// </summary>
        /// <param name="entity">网格人员管理表</param>
        public override void Edit(GridUserTableInfo entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4292001);
                }
                this.ExecutePost(parameterDict, OnEditEvent);
            }
        }

        /// <summary>
        /// 删除网格人员管理表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4293001);
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 添加媒体文件（只能添加一个媒体文件）
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        /// <param name="fileDict">媒体文件字典</param>
        public override void AddMedia(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict)
        {
            if(parameterDict!=null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4291002);
                this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
            }
        }

        /// <summary>
        /// 删除媒体文件（只能删除一个媒体文件）
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void DeleteMedia(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4293002);
                this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
            }
        }

        /// <summary>
        /// 删除网格人员管理表
        /// </summary>
        /// <param name="id">网格人员管理表id</param>
        public void Delete(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4293001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

        /// <summary>
        /// 添加媒体文件（只能添加一个媒体文件）
        /// </summary>
        /// <param name="id">网格管理人员id</param>
        /// <param name="fileDict">媒体文件字典【key=file】</param>
        public void AddMedia(string id,Dictionary<string,object> fileDict)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4291002 },
                {"id",id },
                {"file",(fileDict!=null && fileDict.ContainsKey("file"))?fileDict["file"]:null}
            };
            this.ExecutePost(parameterDict, OnAddMediaEvent,fileDict);
        }

        /// <summary>
        /// 删除媒体文件（只能删除一个媒体文件）
        /// </summary>
        /// <param name="id">媒体文件id</param>
        public void DeleteMedia(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4293002 },
                {"id",id },
            };
            this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
        }

    }
}
