// <copyright file="AreaCodeController.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-29 </date>
// <summary>行政区划管理业务服务类</summary>
// <modify>
// 修改人：×××
// 修改时间：yyyy-mm-dd
// 修改描述：×××
// 版本：1.0
//</modify>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFireManage.Service
{
    /// <summary>
    /// 行政区划管理业务服务类
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
    public class AreaCodeController:BaseServiceControler<AreaCodeInfo>
    {
        /// <summary>
        /// 获取行政区划列表
        /// </summary>
        /// <param name="parameterDict">参数字典</param>
        public override void Get(Dictionary<string, object> parameterDict)
        {
            if(parameterDict!=null)
            {
                if(!parameterDict.ContainsKey("f"))
                {
                    parameterDict.Add("f", 210002);
                }
                this.ExecuteGet(parameterDict, OnQueryEvent);
            }
        }

        /// <summary>
        /// 获取行政区划列表
        /// </summary>
        /// <param name="pac">行政区划代码</param>
        /// <param name="fetchType"></param>
        public void GetList(string pac, int fetchType=3)
        {
            Dictionary<string, object> parameterDict = new Dictionary<string, object>()
            {
                {"f",210002 },
                {"pac",pac },
                {"fetchType",fetchType }
            };
            this.ExecuteGet(parameterDict, OnQueryEvent);
        }
    }
}
