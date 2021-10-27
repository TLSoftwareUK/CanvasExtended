using Microsoft.AspNetCore.Components;
using System.Numerics;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public partial class BECanvasBackend
    {
        public async Task DrawLine(Vector2 start, Vector2 end, PenSettings penSettings)
        {
            await _context.BeginPathAsync();
            if(penSettings.DashLength != 0)
                await _context.SetLineDashAsync(new float[] { penSettings.DashLength, penSettings.DashLength });
            await _context.MoveToAsync(start.X, start.Y);
            await _context.LineToAsync(end.X, end.Y);
            await _context.StrokeAsync();
            await _context.SetLineDashAsync(new float[] { });
        }

        public async Task DrawImage(ElementReference image, Vector2 location)
        {
            await _context.DrawImageAsync(image, location.X, location.Y);
        }
    }
}
