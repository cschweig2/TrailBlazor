using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace TrailBlazor.Helpers
{
    #region Runtime Extension Methods
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask InitializeInactivityTimer<T>(this IJSRuntime JS, 
            DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await JS.InvokeVoidAsync("initializeInactivityTimer", dotNetObjectReference);
        }
    }
    #endregion
}
