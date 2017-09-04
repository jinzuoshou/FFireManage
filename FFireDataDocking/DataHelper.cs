using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using ESRI.ArcGIS.Geodatabase;
using FFireManage;

namespace FFireDataDocking
{
    public static class DataHelper
    {
        public static List<T> GetEntities<T>(this IFeatureClass featureClass)
            where T : class, new()
        {
            if (featureClass == null)
                return null;

            ITable pTable = featureClass as ITable;

            ICursor pCursor = pTable.Search(null, false);
            IRow pRow = pCursor.NextRow();

            List<T> entities = new List<T>();
            while (pRow != null)
            {
                T entity = new T();
                Type type = entity.GetType();
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.GetField); //获取指定名称的属性
                StringBuilder strBuild = new StringBuilder();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    for (int j = 0; j < propertyInfos.Length; j++)
                    {
                        System.Reflection.PropertyInfo info = propertyInfos[j];
                        if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                        {

                        }
                        else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                        {
                            //pDataRow[i] = "Element";
                        }
                        else if (pRow.Fields.Field[i].Name == info.Name)
                        {
                            object[] objAttrs = info.GetCustomAttributes(typeof(CustomAttribute), true);
                            if (objAttrs != null && objAttrs.Length > 0)
                            {
                                CustomAttribute attr = objAttrs[0] as CustomAttribute;
                                if (attr != null)
                                {
                                    if (attr.EnumType != null)
                                    {
                                        int value = 0;
                                        try
                                        {
                                            value = Convert.ToInt32(Enum.Parse(attr.EnumType, Convert.ToString(pRow.get_Value(i))));
                                        }
                                        catch
                                        {
                                            value = 0;
                                        }
                                        finally
                                        {
                                            info.SetValue(entity, value, null);
                                        }
                                    }
                                    else
                                    {
                                        if (!Convert.IsDBNull(pRow.get_Value(i)))
                                        {
                                            info.SetValue(entity, Convert.ChangeType(pRow.get_Value(i), info.PropertyType), null);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (!Convert.IsDBNull(pRow.get_Value(i)))
                                {
                                    info.SetValue(entity, Convert.ChangeType(pRow.get_Value(i), info.PropertyType), null);
                                }
                            }
                        }
                    }
                }
                entities.Add(entity);
                pRow = pCursor.NextRow();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pCursor);
            return entities;
        }
    }
}
