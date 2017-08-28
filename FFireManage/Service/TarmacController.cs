// <copyright file="TarmacController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-23 </date>
// <summary>停机坪业务服务</summary>
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

using FFireManage.Utility;

namespace FFireManage.Service
{
    /// <summary>
    /// 停机坪业务服务类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-23
    /// 修改人：
    /// 修改日期：2017-08-23
    /// 修改备注：无
    /// 版本：1.0
    /// </remarks>
    public class TarmacController:BaseServiceControler<Fire_Tarmac>
    {
        /// <summary>
        /// 获取停机坪列表
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
                parameterDict.Add("f", null);
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增停机坪
        /// </summary>
        /// <param name="entity">停机坪实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Add(Fire_Tarmac entity)
        {
            if(entity!=null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                parameterDict.Add("f", null);
                this.ExecutePost(parameterDict, OnAddEvent, (entity.mediaByteDict == null) ? new Dictionary<string, object>() : entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑停机坪
        /// </summary>
        /// <param name="entity">停机坪实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_Tarmac entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                parameterDict.Add("f", null);
                this.ExecutePost(parameterDict, OnEditEvent);
            }
        }

        /// <summary>
        /// 删除停机坪
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
            if (parameterDict != null)
            {
                parameterDict.Add("f", null);
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 删除停机坪
        /// </summary>
        /// <param name="id">停机坪id</param>
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
                {"f",id },
                { "id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

        /// <summary>
        /// 新增停机坪媒体文件
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
            if (parameterDict != null)
            {
                if(!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", null);
                this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
            }
        }

        /// <summary>
        /// 删除停机坪媒体文件
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
                if(parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", parameterDict);
                this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
            }
        }

        /// <summary>
        /// 新增停机坪媒体文件
        /// </summary>
        /// <param name="id">停机坪id</param>
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
                {"f",null },
                {"id",id }
            };
            this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
        }

        /// <summary>
        /// 删除停机坪媒体文件
        /// </summary>
        /// <param name="id">媒体文件id</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public void DeleteMedia(String id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",null },
                {"id",id }
            };
        }
    }
}
