using System.Numerics;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public interface IBackend
    {
        Task SetScale(double zoom);

        Task SetOrigin(Vector2 origin);

        Task RenderParts();

        Task Clear();

        IPrimitiveDrawer GetPrimitiveDrawer();           
    }
}
