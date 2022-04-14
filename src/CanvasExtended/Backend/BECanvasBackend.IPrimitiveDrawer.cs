using Microsoft.AspNetCore.Components;
using System.Numerics;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public partial class BECanvasBackend
    {
        public async Task DrawLine(Vector2 start, Vector2 end, PenSettings penSettings)
        {
            if (!LineIntersects(_origin.X, _origin.Y, _actualWidth, _actualHeight, start, end))
                return;

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

        private bool LineIntersects(double x, double y, double width, double length, Vector2 lineStart, Vector2 lineEnd)
        {
            double x2 = x + width;
            double y2 = y + length;

            //Run quick check to remove those with start and end out of bound
            if (lineStart.X < x && lineEnd.X < x) //All to the left
                return false;

            if (lineStart.X > x2 && lineEnd.X > x2) //All to the right
                return false;

            if (lineStart.Y < y && lineEnd.Y < y) //All under
                return false;

            if (lineStart.Y > y2 && lineEnd.Y > y2) //All above
                return false;

            return true;
        }
    }
}
