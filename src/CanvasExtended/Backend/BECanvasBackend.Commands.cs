using System.Numerics;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public partial class BECanvasBackend 
    {
        private Vector2? _clickLocation;

        public async Task PassClick(Vector2 location)
        {            
            _clickLocation = location;
        }

        public async Task<Vector2?> GetClickAsync()
        {
            while (!_clickLocation.HasValue)
            {
                await Task.Delay(100);
            }

            Vector2? result = _clickLocation.Value;
            _clickLocation = null;

            return result;            
        }
    }
}
