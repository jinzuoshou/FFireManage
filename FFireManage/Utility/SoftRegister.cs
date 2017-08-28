using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FFireManage.Utility
{
    public class SoftRegister
    {
        /// <summary>
        /// 获取计算机硬盘卷标号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 获取计算机CPU序列号
        /// </summary>
        /// <returns></returns>
        public static string GetCpuSerialNumber()
        {
            string cpuSerialNumber = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuCollection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuCollection)
            {
                cpuSerialNumber = myObject.Properties["Processorid"].Value.ToString();
            }
            return cpuSerialNumber;
        }

        /// <summary>
        /// 获得计算机Mac地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            string macAddress = "";
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                if ((bool)managementObject["IPEnabled"] == true)
                    macAddress = managementObject["MacAddress"].ToString();

                managementObject.Dispose();
            }
            return macAddress.Replace(":", "").Replace("-", "");
        }
    }
}
