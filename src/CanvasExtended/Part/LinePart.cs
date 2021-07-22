using System.Numerics;
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

        public void Render(IPrimitveDrawer backend)
        {            
            backend.DrawLine(Start, End, PenSettings);
        }
    }
}
