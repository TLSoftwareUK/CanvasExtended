using System;
using System.Collections.Generic;
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
    }
}
