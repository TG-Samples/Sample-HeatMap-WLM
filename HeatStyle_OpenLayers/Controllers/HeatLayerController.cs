using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ThinkGeo.MapSuite.Drawing;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.WebApi;

namespace ThinkGeo.MapSuite.Samples
{
    [RoutePrefix("HeatLayer")]
    public class HeatLayerController : ApiController
    {
        private static readonly string baseDirectory;

        static HeatLayerController()
        {
            baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        }

        [HttpGet]
        [Route("{z}/{x}/{y}")]
        public HttpResponseMessage GetHeatLayer(int z, int x, int y)
        {
            ShapeFileFeatureSource shapeFileFeatureSource = new ShapeFileFeatureSource(Path.Combine(baseDirectory, "usEarthquake.shp"));
            shapeFileFeatureSource.Projection = new Proj4Projection(4326, 3857);

            HeatLayer heatLayer = new HeatLayer(shapeFileFeatureSource);
            heatLayer.HeatStyle = new HeatStyle(10, 150, "MAGNITUDE", 0, 12, 100, DistanceUnit.Kilometer);

            LayerOverlay layerOverlay = new LayerOverlay();
            layerOverlay.Layers.Add(heatLayer);

            return DrawTileImage(layerOverlay, z, x, y);
        }

        private HttpResponseMessage DrawTileImage(LayerOverlay layerOverlay, int z, int x, int y)
        {
            using (Bitmap bitmap = new Bitmap(256, 256))
            {
                PlatformGeoCanvas geoCanvas = new PlatformGeoCanvas();
                RectangleShape boundingBox = WebApiExtentHelper.GetBoundingBoxForXyz(x, y, z, GeographyUnit.Meter);
                geoCanvas.BeginDrawing(bitmap, boundingBox, GeographyUnit.Meter);
                layerOverlay.Draw(geoCanvas);
                geoCanvas.EndDrawing();

                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Png);

                HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.OK);
                msg.Content = new ByteArrayContent(ms.ToArray());
                msg.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return msg;
            }
        }
    }
}