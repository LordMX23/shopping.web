using shopping.web.DTOs;

namespace shopping.web.Pages
{
    public partial class Index
    {
        private IEnumerable<ArticuloDto> ArticuloDtos { get; set; } = new List<ArticuloDto>();

        protected override async Task OnInitializedAsync()
        {
            ArticuloDtos = await MyArticuloRepositorio.GetAllArticulo();
        }
    }
}
