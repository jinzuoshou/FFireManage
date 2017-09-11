// <copyright file="DangerousFacilitiesController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-29 </date>
// <summary>林区危险及重要设施</summary>
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
    /// 林区危险及重要设施
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
    public class DangerousFacilitiesController:BaseServiceControler<Fire_DangerousFacilities>
    {
        /// <summary>
        /// 获取林区危险及重要设施列表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if(!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4180001);
                }
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增林区危险及重要设施
        /// </summary>
        /// <param name="entity">林区危险及重要设施实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Add(Fire_DangerousFacilities entity)
        {
            if(entity!=null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if(!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4181001);
                }
                this.ExecutePost(parameterDict, OnAddEvent, entity.mediaByteDict,entity:entity);
            }
        }

        /// <summary>
        /// 编辑林区危险及重要设施
        /// </summary>
        /// <param name="entity">林区危险及重要设施实体对象</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-29
        /// 修改人：qipengfei
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_DangerousFacilities entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4182001);
                }
                this.ExecutePost(parameterDict, OnEditEvent);
            }
        }

        /// <summary>
        /// 删除林区危险及重要设施
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
            if(parameterDict!=null)
            {
                if(!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 4183001);
                }
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 删除林区危险及重要设施
        /// </summary>
        /// <param name="id">林区危险及重要设施id</param>
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
                {"f",4183001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

    }
}
