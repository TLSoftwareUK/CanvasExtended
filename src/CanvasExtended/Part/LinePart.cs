using System.Numerics;
using System.Threading.Tasks;
using TLS.CanvasExtended.Backend;

namespace TLS.CanvasExtended.Part
{
    public class LinePart : IPart
    {
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }
        public PenSettings PenSettings {  get; set; }        

        public LinePart()
        {
            Start = new Vector2();
            End = new Vector2();
            PenSettings = new PenSettings();
        }

        public async Task Render(IPrimitiveDrawer backend)
        {            
            await backend.DrawLine(Start, End, PenSettings);
        }
    }
}
