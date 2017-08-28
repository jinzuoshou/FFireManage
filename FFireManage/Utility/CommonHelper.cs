﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FFireManage.Utility
{
    public static class CommonHelper
    {
        /// <summary>
        /// 实体对象拼接http访问的参数字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToUrlParas(this object obj)
        {
            try
            {
                Type type = obj.GetType(); //获取类型
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.GetField); //获取指定名称的属性
                StringBuilder strBuild = new StringBuilder();
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    PropertyInfo propertyInfo = propertyInfos[i];
                    
                    object[] objAttrs = propertyInfo.GetCustomAttributes(typeof(CustomAttribute), true);
                    bool isRequired = true;
                    if (objAttrs.Length > 0)
                    {
                        CustomAttribute attr = objAttrs[0] as CustomAttribute;
                        if (attr != null)
                        {
                            isRequired = attr.IsRequired;
                        }
                    }
                    if (isRequired)
                    {
                        string name = propertyInfo.Name;
                        object value = propertyInfo.GetValue(obj, null);
                        if (value != null)
                        {
                            strBuild.AppendFormat("{0}={1}&", name, value);
                        }
                        else
                        {
                            strBuild.AppendFormat("{0}=&", name);
                        }
                    }
                }
                return strBuild.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 实体对象属性拼接字典
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string,object> ObjectToDict(this object obj)
        {
            try
            {
                Type type = obj.GetType(); //获取类型
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.GetField); //获取指定名称的属性
                Dictionary<string, object> valueDict = new Dictionary<string, object>();
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    PropertyInfo propertyInfo = propertyInfos[i];

                    object[] objAttrs = propertyInfo.GetCustomAttributes(typeof(CustomAttribute), true);
                    bool isRequired = true;
                    if (objAttrs.Length > 0)
                    {
                        CustomAttribute attr = objAttrs[0] as CustomAttribute;
                        if (attr != null)
                        {
                            isRequired = attr.IsRequired;
                        }
                    }
                    if (isRequired)
                    {
                        string name = propertyInfo.Name;
                        object value = propertyInfo.GetValue(obj, null);
                        if (value != null)
                        {
                            valueDict.Add(name, value);
                        }
                        else
                        {
                            valueDict.Add(name, value);
                        }
                    }
                }
                return valueDict;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 将枚举类型根据name和value组装成对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<object> GetDataSource<T>(T obj) 
        {
            List<object> objList = new List<object>();
            if(obj is Enum)
            {
                
                Array valueArray = Enum.GetValues(typeof(T));
                foreach(object value in valueArray)
                {
                    string name = Enum.GetName(typeof(T), value);
                    objList.Add(new {Name=name,Value=(int)value });
                }
            }
            return objList;
        }

        public static IDictionary<string, string> ObjectDescriptionToDict<T>(this T obj)
        {
            try
            {
                if (obj == null)
                    obj = (T)Activator.CreateInstance<T>();
                Type type = obj.GetType(); //获取类型
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty| BindingFlags.GetField); //获取指定名称的属性
                Dictionary<string, string> valueDict = new Dictionary<string, string>();
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    PropertyInfo propertyInfo = propertyInfos[i];

                    object[] objAttrs = propertyInfo.GetCustomAttributes(typeof(CustomAttribute), true);
                    string description = string.Empty;
                   
                    if (objAttrs.Length > 0)
                    {
                        CustomAttribute attr = objAttrs[0] as CustomAttribute;
                        if (attr != null)
                        {
                            description = attr.Description;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(description))
                    {
                        string name = propertyInfo.Name;
                        valueDict.Add(name, description);
                    }
                }
                return valueDict;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 判断字符串是否为数字
        /// </summary>
        /// <param name="oText">字符串</param>
        /// <returns></returns>
        public static bool IsNumberic(this string oText)
        {
            try
            {
                int var1 = Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
