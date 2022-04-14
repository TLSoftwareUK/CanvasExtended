using netDxf;
using netDxf.Objects;
using TLS.CanvasExtended.Backend;
using System.Numerics;

namespace TLS.CanvasExtended.Source.Dxf
{
    internal static class ExtensionMethod
    {
        public static async Task RenderDxf(this IPrimitiveDrawer backend, DxfDocument doc, float x, float y, float width, float length)
        {  
            Console.WriteLine($"Drawing lines, {doc.Lines.Count()} total");
            await LineRender.DrawLines(backend, doc.Lines);
            Console.WriteLine($"Drawing polylines, {doc.Polylines.Count()} total");
            await LineRender.DrawPolylines(backend, doc.Polylines);
            Console.WriteLine($"Drawing LW lines, {doc.LwPolylines.Count()} total");
            await LineRender.DrawLwPolylines(backend, doc.LwPolylines);

            Console.WriteLine("DXF Complete");
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
