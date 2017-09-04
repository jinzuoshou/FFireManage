// <copyright file="FireHBrigadeCotroller.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-23 </date>
// <summary>半专业森林消防队业务服务</summary>
// <modify>
// 修改人：
// 修改时间：yyyy-mm-dd
// 修改描述：
// 版本：1.0
//</modify>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFireManage.Utility;

namespace FFireManage.Service
{
    /// <summary>
    /// 半专业森林消防队业务服务类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-23
    /// 修改人：qipengfei
    /// 修改日期：yyyy-mm-dd
    /// 修改备注：无
    /// 版本：1.0
    /// </remarks>
    public class FireHBrigadeController:BaseServiceControler<Fire_HBrigade>
    {
        /// <summary>
        /// 获取半专业森林消防队列表
        /// </summary>
        /// <param name="parameterDict">参数字典【查询参数组成的字典】</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if(!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4200001);
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增半专业森林消防队
        /// </summary>
        /// <param name="entity">半专业森林消防队实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Add(Fire_HBrigade entity)
        {
            if(entity!=null)
            {
                Dictionary<string, object> parameterDict =entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4201001);
                this.ExecutePost(parameterDict, OnAddEvent, (entity.mediaByteDict == null) ? new Dictionary<string, object>() : entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑半专业森林消防队
        /// </summary>
        /// <param name="entity">半专业森林消防队实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_HBrigade entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4202001);
                this.ExecutePost(parameterDict, OnEditEvent);
            }
        }

        /// <summary>
        /// 删除半专业森林消防队
        /// </summary>
        /// <param name="parameterDict">参数字典【删除参数组成的字典】</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if(!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4203001);
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 新增半专业森林消防队媒体文件
        /// </summary>
        /// <param name="parameterDict">新增媒体参数字典</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void AddMedia(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict)
        {
            if(parameterDict!=null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4201002);
                this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
            }
        }

        /// <summary>
        /// 删除半专业森林消防队媒体文件
        /// </summary>
        /// <param name="parameterDict">删除媒体参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void DeleteMedia(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4203002);
                this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
            }
        }

        /// <summary>
        /// 删除半专业森林消防队
        /// </summary>
        /// <param name="id">半专业森林消防队id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public void Delete(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4203001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

        /// <summary>
        /// 新增半专业森林消防队媒体文件
        /// </summary>
        /// <param name="id">半专业森林消防队id</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public void AddMedia(string id,Dictionary<string,object> fileDict)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4201002 },
                {"id",id }
            };
            this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
        }

        /// <summary>
        /// 删除半专业森林消防队媒体文件
        /// </summary>
        /// <param name="id">媒体id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public void DeleteMedia(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4203002},
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
        }
    }
}
