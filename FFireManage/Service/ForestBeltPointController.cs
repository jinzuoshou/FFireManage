// <copyright file="ForestBeltPointController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-29 </date>
// <summary>防火林带业务服务</summary>
// <modify>
// 修改人：×××
// 修改时间：yyyy-mm-dd
// 修改描述：×××
// 版本：1.0
//</modify>

using FFireManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Service
{
    /// <summary>
    /// 防火林带业务服务类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-29
    /// 修改人：qipengfei
    /// 修改日期：yyyy-mm-dd
    /// 修改备注：无
    /// 版本：1.0
    /// </remarks>
    public class ForestBeltPointController:BaseServiceControler<Fire_ForestBeltPoint>
    {
        /// <summary>
        /// 获取防火林带列表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4160001);
                }
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增防火林带
        /// </summary>
        /// <param name="entity">防火林带实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Add(Fire_ForestBeltPoint entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4161001);
                }
                this.ExecutePost(parameterDict, OnAddEvent, entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑防火林带
        /// </summary>
        /// <param name="entity">防火林带实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_ForestBeltPoint entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4162001);
                }
                this.ExecutePost(parameterDict, OnEditEvent, entity: entity);
            }
        }

        /// <summary>
        /// 删除防火林带
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4163001);
                }
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 删除防火林带
        /// </summary>
        /// <param name="id">防火林带id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public void Delete(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4163001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }
    }
}
