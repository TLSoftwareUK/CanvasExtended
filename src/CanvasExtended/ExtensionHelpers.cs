using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TLS.CanvasExtended
{
    internal static class ExtensionHelpers
    {
        public static (Vector2, Vector2) CombineBounds(Vector2 oStart, Vector2 oEnd, Vector2 nStart, Vector2 nEnd )
        {           
            Vector2 outStart = new Vector2()
            {
                X = nStart.X < oStart.X ? nStart.X : oStart.X,
                Y = nStart.Y < oStart.Y ? nStart.Y : oStart.Y
            };

            Vector2 outEnd = new Vector2()
            {
                X = oEnd.X < nEnd.X ? nEnd.X : oEnd.X,
                Y = oEnd.Y < nEnd.Y ? nEnd.Y : oEnd.Y
            };

            if (oStart == Vector2.Zero)
                outStart = nStart;

            if (nStart == Vector2.Zero)
                outStart = oStart;

            if (oEnd == Vector2.Zero)
                outEnd = nEnd;

            if (nStart == Vector2.Zero)
                outEnd = oEnd;

            return (outStart, outEnd);
        }
    }
}


