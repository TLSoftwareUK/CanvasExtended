using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using TLS.CanvasExtended.Part;

namespace TLS.CanvasExtended.Backend
{
    public partial class BECanvasBackend : IBackend, IPrimitiveDrawer, IBackendHost, ICanvasInteractions
    {
        private Canvas2DContext _context;
        private PartManager _partManager;
        private int _width, _height;

        private double _scale;
               

        public BECanvasBackend(Canvas2DContext context, PartManager partManager, int width, int height)
        {
            _context = context;
            _partManager = partManager;
            _width = width;
            _height = height;
        }

        public async Task SetScale(double zoom)
        {
            _scale = zoom;
            await _context.TranslateAsync(_width / 2, _height / 2);
            await _context.ScaleAsync(zoom, zoom);            
        }

        public async Task RenderParts()
        {
            Console.WriteLine($"Parts {_partManager.Parts.Count}");
            await _partManager.Render(this);
        }

        public async Task Clear()
        {            
            await _context.SetTransformAsync(1, 0, 0, 1, 0, 0);
            await _context.ClearRectAsync(0, 0, _width, _height);

            #if DEBUG
              await _context.SetFillStyleAsync("aliceblue");
            #else
              await _context.SetFillStyleAsync("lightgrey");
            #endif                
            
            await _context.FillRectAsync(0, 0, _width, _height);            
            await this._context.TransformAsync(1, 0, 0, -1, 0, _height);
        }

        public IPrimitiveDrawer GetPrimitiveDrawer()
        {
            return this;
        }

        public async Task SetOrigin(Vector2 origin)
        {
            await _context.TranslateAsync((-_width / 2) + origin.X, (-_height / 2) + origin.Y);
        }
    }
}
