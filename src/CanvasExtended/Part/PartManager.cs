using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using TLS.CanvasExtended.Backend;

namespace TLS.CanvasExtended.Part
{
    public class PartManager
    {
        public List<IPart> Parts { get; private set; }

        public PartManager()
        {
            Parts = new List<IPart>();
        }

        public async Task Render(IPrimitveDrawer backend)
        {
            foreach (IPart part in Parts)
            {
                part.Render(backend);
            }
        }
    }
}
