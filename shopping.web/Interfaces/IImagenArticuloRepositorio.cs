using shopping.web.DTOs;

namespace shopping.web.Interfaces
{
    public interface IImagenArticuloRepositorio
    {
        public Task<int> CrearArticuloImagen(ImagenArticuloDto imagenArticuloDto);
        public Task<int> BorrarArticuloImagenPorImagenId(int imagenId);
        public Task<int> BorrarArticuloImagenPorArticuloId(int articuloId);
        public Task<int> BorrarArticuloImagenPorUrlImagen(string urlImagen);
        public Task<IEnumerable<ImagenArticuloDto>> GetImagenesArticulo(int articuloId);

    }
}
