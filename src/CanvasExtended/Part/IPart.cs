using System.Numerics;
using System.Threading.Tasks;
using TLS.CanvasExtended.Backend;

namespace TLS.CanvasExtended.Part
{
    public interface IPart
    {
        Task Render(IPrimitiveDrawer backend);

        (Vector2, Vector2) GetBounds();
    }
}
