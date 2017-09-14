// <copyright file="SmartForm.cs" company="Hysoft">
// Copyright (c) Hysoft. All rights reserved.
// </copyright>
// <author>qipengfei</author>
// <date> 2017-08-24 </date>
// <summary>WinForm 窗体自动取值赋值，数据验证帮助类</summary>
// <modify>
// 修改人：×××
// 修改时间：yyyy-mm-dd
// 修改描述：×××
// 版本：1.0
//</modify>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFireManage.Utility
{
    /// <summary>
    /// Winform 窗体自动取值赋值，数据验证帮助类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-24
    /// 修改人：
    /// 修改日期：yyyy-mm-dd
    /// 修改备注：无
    /// 版本：1.0
    /// </remarks>
    public static class SmartForm
    {
        /// <summary>
        /// 从表现层容器(窗体或者布局控件)里获取数据组装成特定类型的实体对象
        /// </summary>
        /// <typeparam name="T">实体对象类型</typeparam>
        /// <param name="controls">表现层容器（一般是Form或者布局控件）</param>
        /// <param name="obj">数据实体</param>
        /// <returns>从表现层容器取值后的实体对象</returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public static T GetEntity<T>(Control.ControlCollection controls, T obj = default(T))
            where T : class, new()
        {
            return ControlHelper.EvaluateContainer<T>(controls,obj);
        }

        /// <summary>
        /// 把实体对象数据填充到表现层容器，实体对象一般是IDictionary或者实体类对象
        /// </summary>
        /// <param name="container">数据表现层容器（一般是Form或者Div）</param>
        /// <param name="data">单条数据实体，一般是IDictionary或者实体类对象</param>
        /// <returns>从表现层容器取值后的实体对象</returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public static void Fill(Control.ControlCollection controls, Object data)
        {
            ControlHelper.SetContainerValue(controls, data);
        }

        /// <summary>
        /// 基于控件进行简单数据校验
        /// </summary>
        /// <param name="controls">表现层容器</param>
        /// <param name="dict">用于校验的字典</param>
        public static bool Validator(Control.ControlCollection controls, IDictionary<string, string> dict)
        {
            for (int i = controls.Count - 1; i >= 0; i--)
            {
                Control control = controls[i];
                if (control is Label ||
                    control is LinkLabel ||
                    control is Button)
                    continue;
                string showName = dict.Where(p => control.AccessibleName.ToLower()==p.Key.ToLower()).Select(p => p.Value + "：").FirstOrDefault();
                if (!string.IsNullOrEmpty(showName) && !string.IsNullOrEmpty(control.AccessibleDescription))
                {
                    string[] arr = control.AccessibleDescription.Split(';');
                    string text = ControlHelper.Evaluate(control).ToString();

                    string messageInfo = string.Empty;
                    foreach (var item in arr)
                    {
                        #region 验证规则

                        if (item == "required")
                        {
                            if (string.IsNullOrWhiteSpace(text)) { messageInfo += "必填；"; }
                        }
                        else if (item == "date")
                        {
                            try
                            {
                                Convert.ToDateTime(text);
                            }
                            catch
                            {
                                messageInfo += "日期输入格式不正确；";
                            }
                        }
                        else if (item == "int")
                        {
                            if (!IsInt(text))
                            {
                                { messageInfo += "输入值必须是整数；"; }
                            }
                        }
                        else if (item == "double")
                        {
                            try
                            {
                                Convert.ToDouble(text);
                            }
                            catch
                            {
                                messageInfo += "输入值必须浮点型数值；";
                            }
                        }
                        else if (item == "digit")
                        {
                            if (!IsNumeric(text))
                            {
                                messageInfo += "只能输入数字；";
                            }
                        }
                        else if (item.StartsWith("range"))
                        {
                            string[] strArr = item.Split(':');
                            if (strArr.Length != 3)
                                continue;
                            if (!Regex.IsMatch(text, @strArr[1]))
                            {
                                messageInfo += string.Format(strArr[2], "输入字符的区间范围为");
                            }
                        }
                        else if (item.StartsWith("length"))
                        {
                            string[] strArr = item.Split(':');
                            if (strArr.Length != 3)
                                continue;
                            if (!Regex.IsMatch(text, @strArr[1]))
                            {
                                messageInfo += string.Format(strArr[2], "输入的字符的长度范围为");
                            }
                        }
                        #endregion
                    }
                    if (!string.IsNullOrEmpty(messageInfo))
                    {
                        ShowInfo(control.FindForm(), showName + messageInfo);
                        control.Focus();
                        return false;
                    }
                }
                if (control.HasChildren)
                {
                    return Validator(control.Controls, dict);
                }
            }

            return true;
        }

        /// <summary>
        /// 将表现层控件集合的控件的Enabled属性为false
        /// </summary>
        /// <param name="controls">表现层控件集合</param>
        /// <param name="exceptControls">不需要将Enabled属性为false控件集合</param>
        public static void SetControlsEnabled(Control.ControlCollection controls,List<Control> exceptControls=null)
        {
            foreach(Control control in controls)
            {
                if (exceptControls == null)
                    control.Enabled = false;
                else
                {
                    foreach (Control exceptControl in exceptControls)
                    {
                        if (exceptControl.Name != control.Name)
                        {
                            control.Enabled = false;
                            continue;
                        }// if
                    }// foreach
                }// else 
            }// foreach
        }// SetControlsEnabled

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?/d*[.]?/d*$");
        }

        /// <summary>
        /// 判断字符串是否为int'
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?/d*$");
        }

        /// <summary>
        /// 显示输出信息
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="into">提示信息</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        private static void ShowInfo(Form form, string into)
        {
            MessageBox.Show(form, into, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    /// <summary>
    /// Winform控件操作帮助类
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-24
    /// 修改人：
    /// 修改日期：yyyy-mm-dd
    /// 修改备注：无
    /// 版本：1.0
    /// </remarks>
    public static class ControlHelper
    {
        /// <summary>
        /// 将控件集合中控件的值映射到实体中对应的属性上
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controls">控件集合</param>
        /// <returns>实体对象</returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        internal static T EvaluateContainer<T>(Control.ControlCollection controls, T obj = default(T))
            where T : class, new()
        {
            if (obj == null)
            {
                obj = (T)Activator.CreateInstance<T>();
            }// if
            foreach (Control control in controls)
            {
                obj=EvaluateRecuceive(control, obj);
            }// foreach
            return obj;
        }

        /// <summary>
        /// 将控件的值映射到实体中对应的属性上
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="obj"></param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        internal static T EvaluateRecuceive<T>(Control control, T obj)
            where T : class, new()
        {
            if (control is Label ||
                control is LinkLabel ||
                control is Button ||
                control is Panel ||
                control is GroupBox)
            {
                return obj;
            } // if
            else
            {
                //控件名称
                string controlName = control.AccessibleName;
                //获取相应类型控件的值
                Object value = Evaluate(control);

                //设置值
                if (value != null && controlName != null)
                {
                    #region 设置值

                    if (obj is IDictionary<String, Object>)
                    {
                        if (((IDictionary<String, Object>)obj).ContainsKey(controlName))
                        {
                            ((IDictionary<String, Object>)obj)[controlName] = value;
                        }// if
                        else
                        {
                            ((IDictionary<String, Object>)obj).Add(controlName, value);
                        }// else
                    }
                    else if (obj is IDictionary)
                    {
                        if (((IDictionary)obj).Contains(controlName))
                        {
                            ((IDictionary)obj).Remove(controlName);
                        }// if
                        else
                        {
                            ((IDictionary)obj).Add(controlName, value);
                        }// else
                    }// else if
                    else
                    {
                        Type objType = obj.GetType();
                        FastType fastType = FastType.Get(objType);
                        FastProperty prop = fastType.GetGetter(controlName);

                        if (prop != null)
                        {
                            try
                            {
                                //类型转换
                                value = ObjectHelper.ToType(prop.Type, value);
                                prop.SetValue(obj, value);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("类型转换出错。\n字段名：" + controlName + ";字段值：" + value + "。\n" + ex.ToString());
                            }
                        }// if
                    }// else 
                    #endregion
                }
            }
            return obj;
        }

        /// <summary>
        /// 完成各种控件的取值
        /// </summary>
        /// <param name="control">控件</param>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        internal static object Evaluate(Control control)
        {
            if (control == null)
                return null;
            if (control is TextBox)
            {
                return ((TextBox)control).Text.Trim();
            }// if
            else if (control is DateTimePicker)
            {
                return ((DateTimePicker)control).Value;
            }// else if
            else if (control is ComboBox)
            {
                object value = ((ComboBox)control).SelectedValue;
                if (value == null)
                {
                    value = ((ComboBox)control).SelectedText;
                }// if
                return value;
            }// else if
            else if (control is CheckBox)
            {
                return ((CheckBox)control).Checked;
            }// else if
            else if (control is RadioButton)
            {
                return ((RadioButton)control).Checked;
            }// else if
            else if (control is RichTextBox)
            {
                return ((RichTextBox)control).Text.Trim();
            }// else if
            else if (control is ListBox)
            {
                //ListBox选中项的文本
                return ((ListBox)control).Text.Trim();
            }// else if
            else if (control is CheckedListBox)
            {
                //ListBox当前选中项的文本
                return ((CheckedListBox)control).Text.Trim();
            }// else if
            else
            {
                return null;
            }// else
        }

        /// <summary>
        /// 把实体对象数据填充到表现层容器，实体对象一般是IDictionary或者实体类对象
        /// </summary>
        /// <param name="container">数据表现层容器（一般是Form或者Div）</param>
        /// <param name="value">单条数据实体，一般是IDictionary或者实体类对象</param>
        /// <returns>从表现层容器取值后的实体对象</returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        internal static void SetContainerValue(Control.ControlCollection controls, Object value)
        {
            if (value == null)
            {
                return;
            }// if

            #region 绑定控件值
            foreach (Control control in controls)
            {
                //控件名称
                string controlName = control.AccessibleName;
                if (!string.IsNullOrEmpty(controlName))
                {
                    if (value is IDictionary<string, object>)
                    {
                        var dict = value as IDictionary<string, object>;
                        if (dict.ContainsKey(controlName))
                        {
                            SetValue(control, dict[controlName]);
                            continue;
                        }
                    }// if
                    else if (value is IDictionary)
                    {
                        if (((IDictionary)value).Contains(controlName))
                        {
                            SetValue(control, ((IDictionary)value)[controlName]);
                            continue;
                        } // if
                    }// else if
                    else
                    {
                        Type objType = value.GetType();
                        FastType fastType = FastType.Get(objType);
                        FastProperty prop = fastType.GetGetter(controlName);
                        if (prop != null)
                        {
                            //类型转换          
                            SetValue(control, prop.GetValue(value));
                            continue;
                        }// if
                    }// else 
                }// if

                // if we didn't find it here recurse into child containers
                if (control.HasChildren)
                {
                    SetContainerValue(control.Controls, value);
                }
            }// foreach
            #endregion
        }

        /// <summary>
        /// 为控件赋值
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="value">值</param>
        /// <returns>是否赋值成功</returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public static bool SetValue(Control control, object value)
        {
            if (value == null)
                return false;

            // TODO 完成各种控件的赋值
            if (control is Label ||
                control is Panel ||
                control is TabControl ||
                control is Button ||
                control is LinkLabel ||
                control is GroupBox)
            {
                return false;
            }// if
            else if (control is TextBox)
            {
                ((TextBox)control).Text = value.ToString();
                return true;
            } //else if
            else if (control is RichTextBox)
            {
                ((RichTextBox)control).Text = value.ToString();
                return true;
            }// else if
            else if (control is CheckBox)
            {
                if (value is bool)
                {
                    ((CheckBox)control).Checked = (bool)value;
                    return true;
                }// if
                else
                {
                    (control as CheckBox).Checked = Boolean.Parse(value.ToString());
                    return true;
                }// else
            }// else if
            else if (control is DateTimePicker)
            {
                if (value is string)
                {
                    try
                    {
                        (control as DateTimePicker).Value = Convert.ToDateTime(value);
                        return true;
                    }
                    catch
                    {
                        try
                        {
                            string year = value.ToString().Substring(0, 4);
                            DateTime time = new DateTime(Convert.ToInt32(year), 1, 1);
                            (control as DateTimePicker).Value = time;

                            return true;
                        }
                        catch
                        {
                            return true;
                        }
                    }
                }// if
                else if (value is DateTime)
                {
                    (control as DateTimePicker).Value = (DateTime)(value);
                    return true;
                }// else if
                else if (value is long)
                {
                    (control as DateTimePicker).Value = ObjectHelper.TimeStampToDateTime(Convert.ToInt64(value));
                    return true;
                }// else if
            }// else if
            else if (control is ComboBox)
            {
                ComboBox comboBox = control as ComboBox;
                comboBox.SelectedValue = value;
                if (comboBox.SelectedIndex == -1)
                {
                    comboBox.Text = value.ToString();
                }// if
                return true;
            }// else if
            else if (control is ListBox)
            {
                (control as ListBox).Text = value.ToString();
                return true;
            }// else if
            else if (control is CheckedListBox)
            {
                (control as CheckedListBox).Text = value.ToString();
                return true;
            }// else if
            else if(control is NumericUpDown)
            {
                (control as NumericUpDown).Value = (decimal)value;
                return true;
            }// else if

            control.Text = value.ToString();
            return true;
        }
    }

    /// <summary>
    /// 快速类型声明：类类型、接口类型、数组类型、值类型、枚举类型、类型参数、泛型类型定义，以及开放或封闭构造的泛型类型。
    /// </summary>
    /// <see cref=""></see>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-24
    /// 修改人：
    /// 修改日期：yyyy-mm-dd
    /// 修改备注：无
    /// 版本：1.0
    /// </remarks>
    public class FastType
    {
        private static readonly Dictionary<Type, FastType> _cache = new Dictionary<Type, FastType>();
        private static readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        protected Type _type;
        protected FastProperty[] _setters;
        protected FastProperty[] _getters;

        public FastProperty[] Getters
        {
            get
            {
                return this._getters;
            }
        }

        public FastProperty[] Setters
        {
            get
            {
                return this._setters;
            }
        }

        public FastType(Type type)
        {
            this._type = type;
            this.Initialize();
        }

        public static FastType Get(Type type)
        {
            return FastType.Get(type, (Func<Type, FastType>)null);
        }

        protected static FastType Get(Type type, Func<Type, FastType> CreateFastType)
        {
            FastType._cacheLock.EnterUpgradeableReadLock();
            FastType fastType;
            try
            {
                if (!FastType._cache.TryGetValue(type, out fastType))
                {
                    FastType._cacheLock.EnterWriteLock();
                    try
                    {
                        fastType = CreateFastType == null ? new FastType(type) : CreateFastType(type);
                        FastType._cache[type] = fastType;
                    }
                    finally
                    {
                        FastType._cacheLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                FastType._cacheLock.ExitUpgradeableReadLock();
            }
            return fastType;
        }

        public FastProperty GetGetter(string FastPropertyName)
        {
            return ((IEnumerable<FastProperty>)this._getters).SingleOrDefault<FastProperty>((Func<FastProperty, bool>)(p => p.Info.Name.Equals(FastPropertyName, StringComparison.OrdinalIgnoreCase)));
        }

        public FastProperty GetSetter(string FastPropertyName)
        {
            return ((IEnumerable<FastProperty>)this._setters).SingleOrDefault<FastProperty>((Func<FastProperty, bool>)(p => p.Info.Name.Equals(FastPropertyName, StringComparison.OrdinalIgnoreCase)));
        }

        /// <summary>
        /// 初始化【初始化属性和方法】
        /// </summary>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        private void Initialize()
        {
            this.InitializeProperties();
            this.InitializeMethods();
        }

        protected virtual void InitializeProperties()
        {
            List<FastProperty> fastPropertyList1 = new List<FastProperty>();
            List<FastProperty> fastPropertyList2 = new List<FastProperty>();
            foreach (PropertyInfo property in this.GetProperties(this._type))
            {
                FastProperty fastProperty = new FastProperty(this.GetPropertyName(property), property);
                if (property.CanRead)
                    fastPropertyList2.Add(fastProperty);
                if (property.CanWrite)
                    fastPropertyList1.Add(fastProperty);
            }
            this._setters = fastPropertyList1.ToArray();
            this._getters = fastPropertyList2.ToArray();
        }

        /// <summary>
        /// 初始化方法【虚方法】
        /// </summary>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        protected virtual void InitializeMethods()
        {
        }

        /// <summary>
        /// 根据具体类型获取属性集合【虚方法】
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        protected virtual IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return (IEnumerable<PropertyInfo>)type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// 获取属性名称
        /// </summary>
        /// <param name="p">属性</param>
        /// <returns>属性名称</returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-24
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        protected virtual string GetPropertyName(PropertyInfo p)
        {
            return p.Name;
        }
    }

    /// <summary>
    /// 快速属性
    /// </summary>
    /// <remarks>
    /// 创建人：qipengfei
    /// 创建日期：2017-08-24
    /// 修改人：
    /// 修改日期：yyyy-mm-dd
    /// 修改备注：无
    /// 版本：1.0
    /// </remarks>
    public class FastProperty
    {
        private string _name;
        private PropertyInfo _prop;
        private Type _type;
        private Func<object, object> _getter;
        private Action<object, object[]> _setter;

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public Type Type
        {
            get
            {
                return this._type;
            }
        }

        public PropertyInfo Info
        {
            get
            {
                return this._prop;
            }
        }

        public FastProperty(string name, PropertyInfo property)
        {
            this._name = name;
            this._prop = property;
            this._type = this._prop.PropertyType;
            this.InitializeGetter(this._prop);
            this.InitilizeSetter(this._prop);
        }

        public object GetValue(object instance)
        {
            return this._getter(instance);
        }

        public void SetValue(object instance, object value)
        {
            this._setter(instance, new object[1] { value });
        }

        private void InitializeGetter(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.CanRead)
                return;
            ParameterExpression parameterExpression = Expression.Parameter(typeof(object));
            this._getter = Expression.Lambda<Func<object, object>>((Expression)Expression.Convert((Expression)Expression.Property(propertyInfo.GetGetMethod(true).IsStatic ? (Expression)null : (Expression)Expression.Convert((Expression)parameterExpression, propertyInfo.ReflectedType), propertyInfo), typeof(object)), new ParameterExpression[1]
            {
        parameterExpression
            }).Compile();
        }

        private void InitilizeSetter(PropertyInfo prop)
        {
            if (!prop.CanWrite)
                return;
            MethodInfo setMethod = prop.GetSetMethod(true);
            ParameterExpression parameterExpression1 = Expression.Parameter(typeof(object), "instance");
            ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object[]), "parameters");
            List<Expression> expressionList = new List<Expression>();
            ParameterInfo[] parameters = setMethod.GetParameters();
            for (int index = 0; index < parameters.Length; ++index)
            {
                UnaryExpression unaryExpression = Expression.Convert((Expression)Expression.ArrayIndex((Expression)parameterExpression2, (Expression)Expression.Constant((object)index)), parameters[index].ParameterType);
                expressionList.Add((Expression)unaryExpression);
            }
            this._setter = Expression.Lambda<Action<object, object[]>>((Expression)Expression.Call(setMethod.IsStatic ? (Expression)null : (Expression)Expression.Convert((Expression)parameterExpression1, setMethod.ReflectedType), setMethod, (IEnumerable<Expression>)expressionList), new ParameterExpression[2]
            {
        parameterExpression1,
        parameterExpression2
            }).Compile();
        }
    }

    internal sealed class ObjectHelper
    {
        public static T ToType<T>(object value)
        {
            return (T)ToType(typeof(T), value);
        }

        public static object ToType(Type type, object value)
        {
            if (null == value || value is DBNull ||
                (typeof(string) != type && (value is string) && string.IsNullOrEmpty((string)value)))
            {
                return type.IsValueType ? Activator.CreateInstance(type) : null;
            }

            if (type.IsAssignableFrom(value.GetType()))
            {
                return value;
            }
            else
            {
                try
                {
                    return System.Convert.ChangeType(value, type);
                }
                catch (InvalidCastException)
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(type);

                    if (null == converter)
                    {
                        throw new InvalidCastException(
                            string.Format("TypeConverter Not Found for Type : '{0}'", type.FullName));
                    }

                    if (!converter.CanConvertFrom(value.GetType()))
                    {
                        throw new InvalidCastException(
                            string.Format("TypeConverter '{0}' Can Not Convert From Type : '{1}'",
                                           converter.GetType().FullName, value.GetType().FullName));
                    }

                    return converter.ConvertFrom(value);
                }
            }
        }

        /// <summary>
        /// 时间转时间戳
        /// </summary>
        /// <param name="dateTime">标准时间</param>
        /// <returns>长整型时间戳</returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public static long DateTimeToTimeStamp(DateTime dateTime)
        {
            TimeSpan ts = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 时间戳转标准时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <returns>转换后的标准时间</returns>
        /// <remarks>
        /// 创建人：qipengfei
        /// 创建日期：2017-08-25
        /// 修改人：
        /// 修改日期：yyyy-mm-dd
        /// 修改备注：无
        /// 版本：1.0
        /// </remarks>
        public static DateTime TimeStampToDateTime(long timeStamp)
        {
            DateTime orderTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timeStamp);
            return orderTime;
        }

    }

}// namespace FFireManage.Utility
