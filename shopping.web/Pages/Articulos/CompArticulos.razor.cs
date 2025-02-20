// <auto-generated />
using Microsoft.JSInterop;
using shopping.web.DTOs;
using shopping.web.Helpers;
using shopping.web.Servicios;

namespace shopping.web.Pages.Articulos
{
    public partial class CompArticulos
    {
        private IEnumerable<ArticuloDto> ArticuloDto { get; set; } = new List<ArticuloDto>();
        private bool EstaProcesando { get; set; } = false;
        private int? BorrarArticuloId { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ArticuloDto = await MyArticuloRepositorio.GetAllArticulo();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    await JsRuntime.InvokeVoidAsync("MostrarModalConfirmacionBorrado");
        //}

        private async Task ManejadorOnBorrar(int ArticuloId)
        {
            BorrarArticuloId = ArticuloId;
            await JsRuntime.InvokeVoidAsync("MostrarModalConfirmacionBorrado");
        }

        public async Task ClickConfirmarBorrado(bool confirmado)
        {
            EstaProcesando = true;
            if(confirmado && BorrarArticuloId != null)
            {
                ArticuloDto Articulo = await MyArticuloRepositorio.GetArticulo(BorrarArticuloId.Value);
                foreach (var item in Articulo.ImagenArticulo)
                {
                    var NombreImagen = item.UrlImagenArticulo.Replace($"{NavigationManager.BaseUri}ImagenesArticulos/","");
                    SubidaArchivo.BorrarArchivo(NombreImagen);
                }

                await MyArticuloRepositorio.BorrarArticulo(BorrarArticuloId.Value);
                await JsRuntime.ToastrSuccess("Articulo borrado correctamente");
                ArticuloDto = await MyArticuloRepositorio.GetAllArticulo();
            }
            await JsRuntime.InvokeVoidAsync("OcultarModalConfirmacionBorrado");
            EstaProcesando = false;
        }
    }
}