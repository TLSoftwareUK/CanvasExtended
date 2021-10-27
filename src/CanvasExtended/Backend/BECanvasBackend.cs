using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using TLS.CanvasExtended.Part;

namespace TLS.CanvasExtended.Backend
{
    public partial class BECanvasBackend : IBackend, IPrimitveDrawer, IBackendHost
    {
        private Canvas2DContext _context;
        private PartManager _partManager;
        private int _width, _height;

        public BECanvasBackend(Canvas2DContext context, PartManager partManager, int width, int height)
        {
            _context = context;
            _partManager = partManager;
            _width = width;
            _height = height;
        }

        public async Task SetScale(double zoom)
        {
            await _context.ScaleAsync(zoom, zoom);
        }

        public async Task RenderParts()
        {
            await Clear();
            await _partManager.Render(this);
        }

        public async Task Clear()
        {
            await _context.ClearRectAsync(0, 0, _width, _height);

            #if DEBUG
              await _context.SetFillStyleAsync("aliceblue");
            #else
              await _context.SetFillStyleAsync("lightgrey");
            #endif                
            
            await _context.FillRectAsync(0, 0, _width, _height);
        }

        public IPrimitveDrawer GetPrimitiveDrawer()
        {
            return this;
        }
    }
}
