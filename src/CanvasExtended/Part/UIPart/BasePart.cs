﻿using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using TLS.CanvasExtended.Backend;

namespace TLS.CanvasExtended.Part
{
    public abstract class BasePart : ComponentBase, IPart, IAsyncDisposable
    {
        [CascadingParameter]
        protected PartManager PartManager { get; set; }

        [CascadingParameter]
        protected int CanvasHeight { get; set; } 

        public async ValueTask DisposeAsync()
        {
            PartManager?.Parts?.Remove(this);
        }

        public virtual async Task Render(IPrimitiveDrawer backend)
        { }

        protected override Task OnParametersSetAsync()
        {
            PartManager.Parts.Add(this);
            return base.OnParametersSetAsync();
        }

        public float InvertY(float y)
        {
            return CanvasHeight - y;
        }
    }
}
