using netDxf;
using netDxf.Entities;
using TLS.CanvasExtended.Backend;

namespace TLS.CanvasExtended.Source.Dxf
{
    internal static class LineRender
    {
        public static async Task DrawLines(IPrimitiveDrawer drawer, IEnumerable<Line> lines)
        {            
            PenSettings settings = new PenSettings();
                        
            foreach (Line line in lines)
            {               
               await drawer.DrawLine(line.StartPoint.GetFlatVector2(), line.EndPoint.GetFlatVector2(), settings);
            }
        }

        public static async Task DrawPolylines(IPrimitiveDrawer drawer, IEnumerable<Polyline> polylines)
        {            
            PenSettings settings = new PenSettings();

            foreach (Polyline line in polylines)
            {
                for (int i = 0; i < line.Vertexes.Count - 1; i++)
                {
                    await drawer.DrawLine(line.Vertexes[i].Position.GetFlatVector2(), line.Vertexes[i + 1].Position.GetFlatVector2(), settings);
                }
                if (line.IsClosed)
                {
                    await drawer.DrawLine(line.Vertexes[line.Vertexes.Count - 1].Position.GetFlatVector2(), line.Vertexes[0].Position.GetFlatVector2(), settings);
                }
            }
        }

        public static async Task DrawLwPolylines(IPrimitiveDrawer drawer, IEnumerable<LwPolyline> lwPolylines)
        {            
            PenSettings settings = new PenSettings();

            foreach (LwPolyline line in lwPolylines)
            {
                for (int i = 0; i < line.Vertexes.Count - 1; i++)
                {
                    await drawer.DrawLine(line.Vertexes[i].Position.GetVector2(), line.Vertexes[i + 1].Position.GetVector2(), settings);
                }
                if (line.IsClosed)
                {
                    await drawer.DrawLine(line.Vertexes[line.Vertexes.Count - 1].Position.GetVector2(), line.Vertexes[0].Position.GetVector2(), settings);
                }
            }
        }        
    }
}
