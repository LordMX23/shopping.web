using shopping.web.DTOs;

namespace shopping.web.Interfaces
{
    public interface IArticuloRepositorio
    {
        public Task<ArticuloDto> CreaArticulo(ArticuloDto articuloDto);
        public Task<ArticuloDto> ActualizarArticulo(int articuloId, ArticuloDto articuloDto);
        public Task<int> BorrarArticulo(int articuloId);


        public Task<IEnumerable<ArticuloDto>> GetAllArticulo();
        public Task<ArticuloDto> GetArticulo(int articuloId);
        //public Task<ArticuloDto> NombreArticuloExiste(string nombreArticulo);
    }
}