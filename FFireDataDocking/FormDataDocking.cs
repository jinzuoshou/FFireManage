using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using FFireDataManger;
using FFireManage;

namespace FFireDataDocking
{
    public partial class FormDataDocking : Form
    {
        public FormDataDocking()
        {
            InitializeComponent();
        }

        private void btnAddFireCommand_Click(object sender, EventArgs e)
        {
            IWorkspace workspace = WorkspaceUtility.GetWorkspace(@"F:\广西项目\guangxi\Data\Caches.gdb");
            if (workspace == null)
                return;
            IFeatureDataset featureDataSet = (workspace as IFeatureWorkspace).OpenFeatureDataset("FireInfo");
            IFeatureClass fireCommandFeatureClass = (workspace as IFeatureWorkspace).OpenFeatureClass("Fire_Command");
            ITable pTable = fireCommandFeatureClass as ITable;

            int count = pTable.RowCount(null);

            ICursor pCursor = pTable.Search(null, false);
            IRow pRow = pCursor.NextRow();

            List<Fire_Command> fireCommandList = new List<Fire_Command>();
            while (pRow != null)
            {
                Fire_Command fireCommand = new Fire_Command();
                Type type = fireCommand.GetType();
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.GetField); //获取指定名称的属性
                StringBuilder strBuild = new StringBuilder();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    for(int j=0;j<propertyInfos.Length;j++)
                    {
                        PropertyInfo info = propertyInfos[j];
                        if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                        {
                        }
                        else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                        {
                            //pDataRow[i] = "Element";
                        }
                        else if (pRow.Fields.Field[i].Name==info.Name)
                        {
                            object[] objAttrs = info.GetCustomAttributes(typeof(CustomAttribute), true);
                            if (objAttrs!=null && objAttrs.Length > 0)
                            {
                                CustomAttribute attr = objAttrs[0] as CustomAttribute;
                                if (attr != null)
                                {
                                    if (attr.EnumType != null && attr.EnumType.IsEnum)
                                    {
                                        int value = Convert.ToInt32(Enum.Parse(attr.EnumType, Convert.ToString(pRow.get_Value(i))));
                                        info.SetValue(fireCommand, value, null);
                                    }
                                    else
                                    {
                                        info.SetValue(fireCommand, (pRow.get_Value(i) is DBNull)?"": pRow.get_Value(i), null);
                                    }
                                }
                            }
                            else
                            {
                                info.SetValue(fireCommand, (pRow.get_Value(i) is DBNull) ? "" : pRow.get_Value(i), null);
                            }
                        }
                    }
                }


                fireCommand.shape = Converters.PointToWKT(fireCommand.longitude, fireCommand.latitude);
                fireCommandList.Add(fireCommand);
                pRow = pCursor.NextRow();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pCursor);

            
        }
    }
}
