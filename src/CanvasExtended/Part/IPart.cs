using TLS.CanvasExtended.Backend;

namespace TLS.CanvasExtended.Part
{
    public interface IPart
    {
        void Render(IPrimitveDrawer backend);
    }
}
