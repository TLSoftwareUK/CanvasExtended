using netDxf;
using netDxf.Objects;
using TLS.CanvasExtended.Backend;
using System.Numerics;

namespace TLS.CanvasExtended.Source.Dxf
{
    internal static class ExtensionMethod
    {
        public static async Task RenderDxf(this IPrimitiveDrawer backend, Stream fileData)
        {            
            DxfDocument doc = DxfDocument.Load(fileData);

            doc.ActiveLayout = Layout.ModelSpaceName;

            await LineRender.DrawLines(backend, doc.Lines);
            await LineRender.DrawPolylines(backend, doc.Polylines);
            await LineRender.DrawLwPolylines(backend, doc.LwPolylines);
        }

        public static System.Numerics.Vector3 GetVector3(this netDxf.Vector3 vector)
        {
            return new System.Numerics.Vector3((float)vector.X, (float)vector.Y, (float)vector.Z);
        }

        public static System.Numerics.Vector2 GetFlatVector2(this netDxf.Vector3 vector)
        {
            return new System.Numerics.Vector2((float)vector.X, (float)vector.Y);
        }

        public static System.Numerics.Vector2 GetVector2(this netDxf.Vector2 vector)
        {
            return new System.Numerics.Vector2((float)vector.X, (float)vector.Y);
        }
    }
}
