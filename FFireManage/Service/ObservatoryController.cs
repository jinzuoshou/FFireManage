// <copyright file="ObservatoryController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-29 </date>
// <summary>瞭望台业务服务</summary>
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
    /// 瞭望台业务服务类
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
    public class ObservatoryController:BaseServiceControler<Fire_Observatory>
    {
        /// <summary>
        /// 获取瞭望台列表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4130001);
                }
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增瞭望台
        /// </summary>
        /// <param name="entity">瞭望台实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Add(Fire_Observatory entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4131001);
                }
                this.ExecutePost(parameterDict, OnAddEvent, entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑瞭望台
        /// </summary>
        /// <param name="entity">瞭望台实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_Observatory entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4132001);
                }
                this.ExecutePost(parameterDict, OnEditEvent, entity: entity);
            }
        }

        /// <summary>
        /// 删除瞭望台
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
                    parameterDict.Add("f", 4133001);
                }
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 删除瞭望台
        /// </summary>
        /// <param name="id">瞭望台id</param>
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
                {"f",4133001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }
    }
}
