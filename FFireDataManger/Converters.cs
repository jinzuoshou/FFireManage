using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geometry;
using NetTopologySuite.IO;

namespace FFireDataManger
{
    /// <summary>
    /// This class is used to convert a GeoAPI Geometry to ESRI and vice-versa.
    /// It can also convert a ESRI Geometry to WKB/WKT and vice-versa.
    /// http://www.cnblogs.com/zuiyirenjian/p/3410141.html
    /// </summary>
    public static class Converters
    {
        private static IGeometryFactory3 factory = null;
        static Converters()
        {
            factory = new GeometryEnvironmentClass() as IGeometryFactory3;
        }

        public static byte[] ConvertGeometryToWKB(IGeometry geometry)
        {
            /*
             * https://gis.stackexchange.com/questions/4600/converting-between-esri-geometry-and-wkt-using-arcobjects
            IWkb wkb = geometry as IWkb; //(Where geometry is an instance of IGeometry)
            byte[] wkb_bytes = new byte[wkb.WkbSize];
            int byte_count = wkb.WkbSize;
            wkb.ExportToWkb(ref byte_count, out wkb_bytes[0]);
            */

            ITopologicalOperator oper = geometry as ITopologicalOperator;
            oper.Simplify();

            byte[] b = factory.CreateWkbVariantFromGeometry(geometry) as byte[];
            return b;
        }

        public static byte[] ConvertWKTToWKB(string wkt)
        {
            WKBWriter writer = new WKBWriter();
            WKTReader reader = new WKTReader();
            return writer.Write(reader.Read(wkt));
        }

        public static string ConvertWKBToWKT(byte[] wkb)
        {
            WKTWriter writer = new WKTWriter();
            WKBReader reader = new WKBReader();
            return writer.Write(reader.Read(wkb));
        }

        public static string ConvertGeometryToWKT(this IGeometry geometry)
        {
            byte[] b = ConvertGeometryToWKB(geometry);
            WKBReader reader = new WKBReader();
            GeoAPI.Geometries.IGeometry g = reader.Read(b);
            WKTWriter writer = new WKTWriter();
            return writer.Write(g);
        }

        public static IGeometry ConvertWKTToGeometry(string wkt)
        {
            byte[] wkb = ConvertWKTToWKB(wkt);
            return ConvertWKBToGeometry(wkb);
        }

        public static IGeometry ConvertWKBToGeometry(byte[] wkb)
        {
            IGeometry geom;
            int countin = wkb.GetLength(0);

            factory.CreateGeometryFromWkbVariant(wkb, out geom, out countin);
            return geom;
        }

        public static IGeometry ConvertGeoAPIToESRI(GeoAPI.Geometries.IGeometry geometry)
        {
            WKBWriter writer = new WKBWriter();
            byte[] bytes = writer.Write(geometry);
            return ConvertWKBToGeometry(bytes);
        }

        public static GeoAPI.Geometries.IGeometry ConvertESRIToGeoAPI(IGeometry geometry)
        {
            byte[] wkb = ConvertGeometryToWKB(geometry);
            WKBReader reader = new WKBReader();
            return reader.Read(wkb);
        }

        /// <summary>
        /// POINT(6 10)
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public static string PointToWKT(double longitude, double latitude)
        {
            return string.Format("POINT ({0} {1})", longitude, latitude);
        }
    }
}
