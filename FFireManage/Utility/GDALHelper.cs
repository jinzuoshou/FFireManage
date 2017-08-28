using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OSGeo.OGR;

namespace FFireManage.Utility
{
    /// <summary>
    /// GDAL 帮助类
    /// </summary>
    public static class GDALHelper
    {
        /// <summary>
        /// 通过点经纬度生成Point类型的wkt
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static string LngLatToWktPoint(double lng,double lat)
        {
            string wkt="";
            using (Geometry geometry = new Geometry(wkbGeometryType.wkbPoint))
            {
                geometry.AddPoint_2D(lng, lat);
                geometry.ExportToWkt(out wkt);
            }
            return wkt;
        }

        /// <summary>
        /// 通过坐标点集合生成Linestring类型wkt
        /// </summary>
        /// <param name="coordinateList"></param>
        /// <returns></returns>
        public static string PointsToWktLineString(List<GeoCoordinate> coordinateList)
        {
            string wkt = "";
            using (Geometry geometry = new Geometry(wkbGeometryType.wkbLineString))
            {
                coordinateList.ForEach((c) => 
                {
                    geometry.AddPoint_2D(c.Longitude, c.Latitude);
                });
                geometry.ExportToWkt(out wkt);
            }
            return wkt;
        }

        /// <summary>
        /// 通过坐标点集合生成Polygon类型wkt
        /// </summary>
        /// <param name="coordinateList"></param>
        /// <returns></returns>
        public static string PointsToWktPolygon(List<GeoCoordinate> coordinateList)
        {
            string wkt = "";
            using (Geometry geo = new Geometry(wkbGeometryType.wkbPolygon))
            {
                using (Geometry ring = new Geometry(wkbGeometryType.wkbLinearRing))
                {
                    coordinateList.ForEach((c) =>
                    {
                        ring.AddPoint_2D(c.Longitude, c.Latitude);
                    });
                    geo.AddGeometry(ring);
                }
                geo.ExportToWkt(out wkt);
            }
            return wkt;
        }

    }

    /// <summary>
    /// 自定义地理对象类（包含经度、纬度、海拔）
    /// </summary>
    public class GeoCoordinate
    {
        private double latitude;
        private double longitude;
        private double altitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public double Altitude
        {
            get { return altitude; }
            set { altitude = value; }
        }

        public GeoCoordinate() { }

        public GeoCoordinate(double longitude, double latitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public GeoCoordinate(double longitude, double latitude, double altitude)
            : this(longitude, latitude)
        {
            this.altitude = altitude;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Latitude, Longitude, Altitude);
        }
    }
}
