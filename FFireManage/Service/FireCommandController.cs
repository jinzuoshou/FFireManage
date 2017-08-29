// <copyright file="FireCommandController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-29 </date>
// <summary>森林防火指挥部业务服务</summary>
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
    /// 森林防火指挥部业务服务类
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
    public class FireCommandController:BaseServiceControler<Fire_Command>
    {
        /// <summary>
        /// 获取森林防火指挥部列表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4150001);
                }
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增森林防火指挥部
        /// </summary>
        /// <param name="entity">森林防火指挥部实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Add(Fire_Command entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4151001);
                }
                this.ExecutePost(parameterDict, OnAddEvent, entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑森林防火指挥部
        /// </summary>
        /// <param name="entity">森林防火指挥部实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_Command entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4152001);
                }
                this.ExecutePost(parameterDict, OnEditEvent, entity: entity);
            }
        }

        /// <summary>
        /// 删除森林防火指挥部
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
                    parameterDict.Add("f", 4153001);
                }
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 删除森林防火指挥部
        /// </summary>
        /// <param name="id">森林防火指挥部id</param>
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
                {"f",4153001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }
    }
}
