using System.Numerics;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public interface IBackend
    {
        Task SetScale(double zoom);

        Task RenderParts();

        Task Clear();

        IPrimitveDrawer GetPrimitiveDrawer();

        Task<Vector2?> GetClickAsync();
    }
}
