using shopping.web.DTOs;

namespace shopping.web.Interfaces
{
    public interface ICategoriaRepositorio
    {
        public Task<CategoriaDto> CreaCategoria(CategoriaDto categoriaDto);
        public Task<CategoriaDto> ActualizarCategoria(int categoriaId, CategoriaDto categoriaDto);
        public Task<CategoriaDto> BorrarCategoria(int categoriaId);


        public Task<IEnumerable<CategoriaDto>> GetAllCategorias();
        public Task<CategoriaDto> GetCategoria(int categoriaId);
        public Task<CategoriaDto> NombreCategoriaExiste(string nombreCategoria);
        public Task<IEnumerable<CategoriaDto>> GetDropDownCategorias();

    }
}
