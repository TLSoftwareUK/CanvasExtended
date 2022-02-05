using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TLS.CanvasExtended.Backend;

namespace TLS.CanvasExtended.Part.UIPart
{
    internal class InteractivePart : IPart
    {
        private IPart SubPart;

        public InteractivePart(IPart subPart)
        {
            SubPart = subPart;
        }

        public (Vector2, Vector2) GetBounds()
        {
            return SubPart.GetBounds();
        }

        public async Task Render(IPrimitiveDrawer backend)
        {
            SubPart.Render(backend);
        }
    }
}
