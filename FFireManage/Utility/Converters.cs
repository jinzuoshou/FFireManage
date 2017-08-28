using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NetTopologySuite.IO;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;

namespace FFireManage.Utility
{
    /// <summary>
    /// 通过NetTopologySuite进行地理数据转换帮助类
    /// </summary>
    public static class Converters
    {
        /// <summary>
        /// Geometry转WKT
        /// </summary>
        /// <param name="geometry"></param>
        /// <returns></returns>
        public static string GeometryToWKT(IGeometry geometry)
        {
            WKTWriter wktWriter = new WKTWriter();
            return wktWriter.Write(geometry);
        }

        /// <summary>
        /// 经纬度点转WKT
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static string LngLatToWKT(double lng,double lat)
        {
            IGeometry geometry = new Point(lng, lat);
            WKTWriter wktWriter = new WKTWriter();
            return wktWriter.Write(geometry);
        }

    }
}
