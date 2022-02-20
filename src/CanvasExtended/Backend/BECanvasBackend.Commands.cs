using System.Numerics;
using System.Threading.Tasks;

namespace TLS.CanvasExtended.Backend
{
    public partial class BECanvasBackend 
    {
        private Vector2? _clickLocation;
        TaskCompletionSource<Vector2?>? continueClick;

        public async Task PassClick(Vector2 location)
        {            
            _clickLocation = location;
            if(continueClick != null)
                continueClick.TrySetResult(location);
        }

        public async Task<Vector2?> GetPositionAsync()
        {
            await Task.Delay(500);
            continueClick = new TaskCompletionSource<Vector2?>();
            Vector2? result = await continueClick.Task;
            continueClick = null;

            return result;
        }
    }
}
