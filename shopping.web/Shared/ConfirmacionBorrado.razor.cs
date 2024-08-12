using Microsoft.AspNetCore.Components;

namespace shopping.web.Shared
{
    public partial class ConfirmacionBorrado
    {
        public bool ProcesoIniciado { get; set; } = false;
        [Parameter]
        public EventCallback<bool> CambioConfirmacion {  get; set; }
        [Parameter]
        public bool ProcesandoComponentePadre { get; set; }

        protected override void OnParametersSet()
        {
            ProcesoIniciado = ProcesandoComponentePadre;
        }

        protected async Task ConfirmacionOnCambia(bool valor)
        {
            if (valor)
            {
                ProcesoIniciado = true;
            }
            await CambioConfirmacion.InvokeAsync(valor);
        }
    }
}