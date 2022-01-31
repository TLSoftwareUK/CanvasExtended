using System.Numerics;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public interface IBackend
    {
        Task SetScale(double zoom);

        Task RenderParts();

        Task Clear();

        IPrimitiveDrawer GetPrimitiveDrawer();

        Task<Vector2?> GetClickAsync();
    }
}
