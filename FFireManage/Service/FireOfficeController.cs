// <copyright file="FireOfficeController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-23 </date>
// <summary>森林防火办公室业务服务</summary>
// <modify>
// 修改人：qipengfei
// 修改时间：2017-08-29
// 修改描述：
// 版本：1.1
//</modify>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FFireManage.Utility;

namespace FFireManage.Service
{
    /// <summary>
    /// 森林防火办公室业务服务类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-23
    /// 修改人：qipengfei
    /// 修改日期：2017-08-29
    /// 修改备注：修改f的值
    /// 版本：1.0
    /// </remarks>
    public class FireOfficeController:BaseServiceControler<Fire_Office>
    {
        /// <summary>
        /// 获取森林防火办公室列表
        /// </summary>
        /// <param name="parameterDict">参数字典【查询参数组成的字典】</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改f的值
        /// 版本：1.1
        /// </remarks>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if(!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4240001);
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 新增森林防火办公室
        /// </summary>
        /// <param name="entity">森林防火办公室实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改字典f的值
        /// 版本：1.1
        /// </remarks>
        public override void Add(Fire_Office entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if(!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4241001);
                this.ExecutePost(parameterDict, OnAddEvent, (entity.mediaByteDict == null) ? new Dictionary<string, object>() : entity.mediaByteDict, entity: entity);
            }
        }

        /// <summary>
        /// 编辑森林防火办公室
        /// </summary>
        /// <param name="entity">森林防火办公室实体</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改字典f的值
        /// 版本：1.1
        /// </remarks>
        public override void Edit(Fire_Office entity)
        {
            if (entity != null)
            {
                Dictionary<string, object> parameterDict = entity.ObjectToDict();
                if(!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4242001);
                this.ExecutePost(parameterDict, OnEditEvent);
            }
        }

        /// <summary>
        /// 删除森林防火办公室
        /// </summary>
        /// <param name="parameterDict">参数字典【删除参数组成的字典】</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改字典f的值
        /// 版本：1.1
        /// </remarks>
        public override void Delete(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if(!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4243001);
                this.ExecuteGet(parameterDict, OnDeleteEvent);
            }
        }

        /// <summary>
        /// 新增森林防火办公室媒体文件
        /// </summary>
        /// <param name="parameterDict">新增媒体参数字典</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改字典f的值
        /// 版本：1.1
        /// </remarks>
        public override void AddMedia(Dictionary<string, object> parameterDict, Dictionary<string, object> fileDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4241002);
                this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
            }
        }

        /// <summary>
        /// 删除森林防火办公室媒体文件
        /// </summary>
        /// <param name="parameterDict">删除媒体参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改字典f的值
        /// 版本：1.1
        /// </remarks>
        public override void DeleteMedia(Dictionary<string, object> parameterDict)
        {
            if (parameterDict != null)
            {
                if (!parameterDict.ContainsKey("f"))
                    parameterDict.Add("f", 4243002);
                this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
            }
        }

        /// <summary>
        /// 删除森林防火办公室
        /// </summary>
        /// <param name="id">森林防火办公室id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-23
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改字典f的值
        /// 版本：1.1
        /// </remarks>
        public void Delete(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4243001 },
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteEvent);
        }

        /// <summary>
        /// 新增森林防火办公室媒体文件
        /// </summary>
        /// <param name="id">森林防火办公室id</param>
        /// <param name="fileDict">媒体文件参数字典</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改字典f的值
        /// 版本：1.1
        /// </remarks>
        public void AddMedia(string id, Dictionary<string, object> fileDict)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",4241002 },
                {"id",id },
                {"file",(fileDict!=null && fileDict.Count>0)?fileDict["file"]:null }
            };
            this.ExecutePost(parameterDict, OnAddMediaEvent, fileDict);
        }

        /// <summary>
        /// 删除森林防火办公室媒体文件
        /// </summary>
        /// <param name="id">媒体id</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：qipengfei
        /// 修改日期：2017-08-29
        /// 修改备注：修改字典f的值
        /// 版本：1.1
        /// </remarks>
        public void DeleteMedia(string id)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f", 4243002},
                {"id",id }
            };
            this.ExecuteGet(parameterDict, OnDeleteMediaEvent);
        }
    }
}
