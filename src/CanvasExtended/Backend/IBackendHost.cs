using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    internal interface IBackendHost
    {
        public Task PassClick(Vector2 location);
    }
}
