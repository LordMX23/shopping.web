using Microsoft.AspNetCore.Components;
using shopping.web.DTOs;

namespace shopping.web.Pages.Articulos
{
    public partial class CompDetalleArticulo
    {
        [Parameter]
        public int? Id { get; set; }

        private ArticuloDto ArticuloDtos { get; set; } = new ArticuloDto();

        protected override async Task OnInitializedAsync()
        {
            ArticuloDtos = await MyArticuloRepositorio.GetArticulo(Id.Value);
        }
    }
}