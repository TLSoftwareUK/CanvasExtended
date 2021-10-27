using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public interface IPrimitveDrawer
    {
        Task DrawLine(Vector2 start,  Vector2 end, PenSettings penSettings);

        Task DrawImage(ElementReference image, Vector2 location);
    }
}
