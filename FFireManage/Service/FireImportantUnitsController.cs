// <copyright file="FireImportantUnitsController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-25 </date>
// <summary>重点防火单位业务服务</summary>
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
    /// 重点防火单位业务服务类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-25
    /// 修改人：qipengfei
    /// 修改日期：2017-08-25
    /// 修改备注：无
    /// 版本：1.0
    /// </remarks>
    public class FireImportantUnitsController:BaseServiceControler<Fire_ImportantUnits>
    {
        /// <summary>
        /// 获取重点防火单位列表
        /// </summary>
        /// <param name="parameterDict">参数字典【查询参数组成的字典】</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-5
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4230001);
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增重点防火单位
        /// </summary>
        /// <param name="entity">重点防火单位实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：qipengfei
        /// 修改日期：2017-08-25
        /// 修改备注：无
        /// 版本：1.1
        /// </remarks>
        public override void Add(Fire_ImportantUnits entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4231001);
                this.ExecutePost(parameterDict, OnAddEvent, (entity.mediaByteDict == null) ? new Dictionary<string, object>() : entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑重点防火单位
        /// </summary>
        /// <param name="entity">重点防火单位实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Edit(Fire_ImportantUnits entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4232001);
                this.ExecutePost(parameterDict, OnEditEvent);
            }
        }

        /// <summary>
        /// 删除重点防火单位
        /// </summary>
        /// <param name="parameterDict">参数字典【删除参数组成的字典】</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4233001);
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 新增重点防火单位媒体文件
        /// </summary>
        /// <param name="parameterDict">新增媒体参数字典</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public override void AddMedia(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4231002);
                this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
            }
        }

        /// <summary>
        /// 删除重点防火单位媒体文件
        /// </summary>
        /// <param name="parameterDict">删除媒体参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
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
                    parameterDict.Add("f", 4233002);
                this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
            }
        }

        /// <summary>
        /// 删除重点防火单位
        /// </summary>
        /// <param name="id">重点防火单位id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public void Delete(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4233001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

        /// <summary>
        /// 新增重点防火单位媒体文件
        /// </summary>
        /// <param name="id">重点防火单位id</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public void AddMedia(string id, Dictionary<string, object> fileDict)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4231002 },
                {"id",id }
            };
            this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
        }

        /// <summary>
        /// 删除重点防火单位媒体文件
        /// </summary>
        /// <param name="id">媒体id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public void DeleteMedia(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4233002},
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
        }
    }
}
