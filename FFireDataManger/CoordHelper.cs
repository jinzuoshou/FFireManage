using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;

namespace FFireDataManger
{
    public class CoordHelper
    {


        /// <summary>
        /// 十进制经度转为字符型度分秒
        /// </summary>
        /// <param name="dblLongitude"></param>
        /// <returns></returns>
        public static string ConvertDoubleToLongitude(double dblLongitude)
        {
            double num = Math.Floor(dblLongitude);
            double num2 = Math.Floor((double)((dblLongitude - num) * 60.0));
            double num3 = Math.Round((double)(((dblLongitude - num) - (num2 / 60.0)) * 3600.0), 2);
            return (num.ToString() + "°" + num2.ToString() + "′" + num3.ToString() + "″");
            //return (num.ToString() + "\x00b0" + num2.ToString() + "'" + num3.ToString() + "\"");
        }


        public static string ConvertDoubleToLongitude(double dblLongitude, int digits)
        {
            double num = Math.Floor(dblLongitude);
            double num2 = Math.Floor((double)((dblLongitude - num) * 60.0));
            double num3 = Math.Round((double)(((dblLongitude - num) - (num2 / 60.0)) * 3600.0), digits);
            return (num.ToString() + "°" + num2.ToString() + "′" + num3.ToString() + "″");
            //return (num.ToString() + "\x00b0" + num2.ToString() + "'" + num3.ToString() + "\"");
        }


        /// <summary>
        /// 十进制纬度转为字符型度分秒
        /// </summary>
        /// <param name="dblLatitude"></param>
        /// <returns></returns>
        public static string ConvertDoubleToLatitude(double dblLatitude)
        {
            double num = Math.Floor(dblLatitude);
            double num2 = Math.Floor((double)((dblLatitude - num) * 60.0));
            double num3 = Math.Round((double)(((dblLatitude - num) - (num2 / 60.0)) * 3600.0), 2);
            //return (num.ToString() + "\x00b0" + num2.ToString() + "'" + num3.ToString() + "\"");
            return (num.ToString() + "°" + num2.ToString() + "′" + num3.ToString() + "″");
        }

        public static string ConvertDoubleToLatitude(double dblLatitude, int digits)
        {
            double num = Math.Floor(dblLatitude);
            double num2 = Math.Floor((double)((dblLatitude - num) * 60.0));
            double num3 = Math.Round((double)(((dblLatitude - num) - (num2 / 60.0)) * 3600.0), digits);
            //return (num.ToString() + "\x00b0" + num2.ToString() + "'" + num3.ToString() + "\"");
            return (num.ToString() + "°" + num2.ToString() + "′" + num3.ToString() + "″");
        }

        /// <summary>
        /// 字符型度分秒转换成十进制经度
        /// </summary>
        /// <param name="strLongitude"></param>
        /// <returns></returns>
        public static double ConvertLongitudeToDouble(string strLongitude)
        {
            strLongitude = strLongitude.Replace(" ", "");

            double degree = Convert.ToDouble(strLongitude.Substring(0, strLongitude.IndexOf('°')));
            double minutes = Convert.ToDouble(strLongitude.Substring(strLongitude.IndexOf('°') + 1, strLongitude.IndexOf('′') - (strLongitude.IndexOf('°') + 1)));
            double seconds = Convert.ToDouble(strLongitude.Substring(strLongitude.IndexOf('′') + 1, strLongitude.IndexOf('″') - (strLongitude.IndexOf('′') + 1)));

            return degree + (minutes + (seconds / 60)) / 60;
        }

        /// <summary>
        /// 字符型度分秒转换成十进制纬度
        /// </summary>
        /// <param name="strLatitude"></param>
        /// <returns></returns>
        public static double ConvertLatitudeToDouble(string strLatitude)
        {
            strLatitude = strLatitude.Replace(" ", "");

            double degree = Convert.ToDouble(strLatitude.Substring(0, strLatitude.IndexOf('°')));
            double minutes = Convert.ToDouble(strLatitude.Substring(strLatitude.IndexOf('°') + 1, strLatitude.IndexOf('′') - (strLatitude.IndexOf('°') + 1)));
            double seconds = Convert.ToDouble(strLatitude.Substring(strLatitude.IndexOf('′') + 1, strLatitude.IndexOf('″') - (strLatitude.IndexOf('′') + 1)));

            return degree + (minutes + (seconds / 60)) / 60;
        }

        public static IPoint ConvertGcsToPcs(IPoint point, IProjectedCoordinateSystem projectedCoordinateSystem)
        {
            WKSPoint wksPoint = new WKSPoint();

            wksPoint.X = point.X;
            wksPoint.Y = point.Y;

            projectedCoordinateSystem.Forward(1, ref wksPoint);

            IPoint pPoint = new PointClass();
            pPoint.X = wksPoint.X;
            pPoint.Y = wksPoint.Y;

            return pPoint;
        }

        public static IPoint ConvertPcsToGcs(IPoint point, IProjectedCoordinateSystem projectedCoordinateSystem)
        {
            WKSPoint wksPoint = new WKSPoint();

            wksPoint.X = point.X;
            wksPoint.Y = point.Y;

            projectedCoordinateSystem.Inverse(1, ref wksPoint);

            IPoint pPoint = new PointClass();
            pPoint.X = wksPoint.X;
            pPoint.Y = wksPoint.Y;

            return pPoint;
        }
    }
}
