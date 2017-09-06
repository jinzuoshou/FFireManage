// <copyright file="RadioStationController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-29 </date>
// <summary>无线电台站业务服务</summary>
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
    /// 无线电台站业务服务类
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
    public class RadioStationController:BaseServiceControler<Fire_RadioStation>
    {
        /// <summary>
        /// 获取无线电台站列表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4140001);
                }
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增无线电台站
        /// </summary>
        /// <param name="entity">无线电台站实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Add(Fire_RadioStation entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4141001);
                }
                this.ExecutePost(parameterDict, OnAddEvent, entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑无线电台站
        /// </summary>
        /// <param name="entity">无线电台站实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_RadioStation entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4142001);
                }
                this.ExecutePost(parameterDict, OnEditEvent);
            }
        }

        /// <summary>
        /// 删除无线电台站
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
                    parameterDict.Add("f", 4143001);
                }
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 删除无线电台站
        /// </summary>
        /// <param name="id">无线电台站id</param>
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
                {"f",4143001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }
    }
}
