using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;

namespace FFireDataDocking.Job
{
    public class HelloJob : IJob
    {
        private static FormMain __instance = null;
        public void Execute(IJobExecutionContext context)
        {

            if (isOpen("FormMain"))
            {
                //获取当前Form1实例
                __instance = (FormMain)Application.OpenForms["FormMain"];
                //随机生成小于100的数
                string num = new Random().Next(100).ToString();
                //通过方法更新消息
                __instance.SetMsg(num);
            }
            else
            {
                //__instance = new Form1("0");
                //__instance.Show();

            }

        }
        /// <summary>
        /// 判断窗体是否打开
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        private bool isOpen(string appName)
        {
            FormCollection collection = Application.OpenForms;
            foreach (Form form in collection)
            {
                if (form.Name == appName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
