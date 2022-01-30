﻿using System;
using System.Collections.Generic;
using System.Linq;
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


        public void Render(IPrimitveDrawer backend)
        {
            SubPart.Render(backend);
        }
    }
}
