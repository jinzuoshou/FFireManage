using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;

namespace FFireDataManger
{
    public class WorkspaceUtility
    {
        /// <summary>
        /// 获取GDB或MDB工作空间
        /// </summary>
        /// <param name="path">gdb或mdb数据库路径</param>
        /// <returns>gdb或mdb工作空间</returns>
        public static IWorkspace GetWorkspace(String path)
        {
            IWorkspaceFactory workspaceFactory;
            IWorkspace workspace = null;

            try
            {

                if (path.EndsWith(".gdb"))
                {
                    workspaceFactory = new FileGDBWorkspaceFactoryClass();
                    workspace = workspaceFactory.OpenFromFile(path, 0);

                }
                else if (path.EndsWith(".mdb"))
                {
                    workspaceFactory = new AccessWorkspaceFactoryClass();
                    workspace = workspaceFactory.OpenFromFile(path, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接到地理空间数据库失败:\r\n" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return workspace;
        }

        /// <summary>
        /// 获取远程地理工作空间（SDE）
        /// </summary>
        /// <param name="server">远程服务地址</param>
        /// <param name="instance">数据库实例</param>
        /// <param name="user">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="database">数据库</param>
        /// <param name="version">版本</param>
        /// <returns>sde工作空间</returns>
        public static IWorkspace GetWorkspace(String server, String instance, String user, String password, String database, String version)
        {
            IWorkspace workspace = null;
            // Create and populate the property set
            ESRI.ArcGIS.esriSystem.IPropertySet propertySet = new ESRI.ArcGIS.esriSystem.PropertySetClass();
            propertySet.SetProperty("SERVER", server);
            propertySet.SetProperty("INSTANCE", instance);
            propertySet.SetProperty("DATABASE", database);
            propertySet.SetProperty("USER", user);
            propertySet.SetProperty("PASSWORD", password);
            propertySet.SetProperty("VERSION", version);
            ESRI.ArcGIS.Geodatabase.IWorkspaceFactory2 workspaceFactory;
            workspaceFactory = (IWorkspaceFactory2)new ESRI.ArcGIS.DataSourcesGDB.SdeWorkspaceFactoryClass();

            try
            {
                workspace = workspaceFactory.Open(propertySet, 0);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("连接到地理空间数据库失败:\r\n" + Ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return workspace;
        }
    }
}
