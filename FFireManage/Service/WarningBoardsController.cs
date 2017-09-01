﻿// <copyright file="WarningBoardsController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-09-01 </date>
// <summary>大型警示牌业务服务</summary>
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
    /// 大型警示牌业务服务类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-09-01
    /// 修改人：
    /// 修改日期：
    /// 修改备注：
    /// 版本：1.0
    /// </remarks>
    public class WarningBoardsController:BaseServiceControler<Fire_WarningBoards>
    {
        /// <summary>
        /// 获取大型警示牌列表
        /// </summary>
        /// <param name="parameterDict">参数字典【查询参数组成的字典】</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4280001);
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增大型警示牌
        /// </summary>
        /// <param name="entity">大型警示牌实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public override void Add(Fire_WarningBoards entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4281001);
                this.ExecutePost(parameterDict, OnAddEvent, (entity.mediaByteDict == null) ? new Dictionary<string, object>() : entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑大型警示牌
        /// </summary>
        /// <param name="entity">大型警示牌实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_WarningBoards entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4282001);
                this.ExecutePost(parameterDict, OnEditEvent);
            }
        }

        /// <summary>
        /// 删除大型警示牌
        /// </summary>
        /// <param name="parameterDict">参数字典【删除参数组成的字典】</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4283001);
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 新增大型警示牌媒体文件
        /// </summary>
        /// <param name="parameterDict">新增媒体参数字典</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public override void AddMedia(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4281002);
                this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
            }
        }

        /// <summary>
        /// 删除大型警示牌媒体文件
        /// </summary>
        /// <param name="parameterDict">删除媒体参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public override void DeleteMedia(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4283002);
                this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
            }
        }

        /// <summary>
        /// 删除森林防火办公室
        /// </summary>
        /// <param name="id">森林防火办公室id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public void Delete(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4283001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

        /// <summary>
        /// 新增大型警示牌媒体文件
        /// </summary>
        /// <param name="id">大型警示牌id</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public void AddMedia(string id, Dictionary<string, object> fileDict)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4281002 },
                {"id",id }
            };
            this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
        }

        /// <summary>
        /// 删除大型警示牌媒体文件
        /// </summary>
        /// <param name="id">媒体id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-09-01
        /// 修改人：
        /// 修改日期：
        /// 修改备注：
        /// 版本：1.0
        /// </remarks>
        public void DeleteMedia(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4283002},
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
        }
    }
}