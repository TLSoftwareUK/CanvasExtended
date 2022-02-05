using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using TLS.CanvasExtended.Backend;

namespace TLS.CanvasExtended.Part
{
    public class PartManager
    {
        public List<IPart> Parts { get; private set; }

        public event EventHandler? RedrawRequested;

        public PartManager()
        {
            Parts = new List<IPart>();
        }

        public async Task Render(IPrimitiveDrawer backend)
        {
            foreach (IPart part in Parts)
            {
                await part.Render(backend);
            }
        }

        public void Redraw()
        {
            RedrawRequested?.Invoke(this, new EventArgs());
        }

        public (Vector2, Vector2) GetBounds()
        {
            Vector2 start = Vector2.Zero;
            Vector2 end = Vector2.Zero;

            foreach (IPart part in Parts)
            {
                Vector2 newStart, newEnd;
                (newStart, newEnd) = part.GetBounds();
                (start, end) = ExtensionHelpers.CombineBounds(start, end, newStart, newEnd);
            }

            return (start, end);
        }
    }
}
