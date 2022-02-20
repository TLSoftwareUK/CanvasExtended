using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public interface ICanvasInteractions
    {
        Task<Vector2?> GetPositionAsync();
    }
}
