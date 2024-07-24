using shopping.web.DTOs;

namespace shopping.web.Repositorios
{
    public interface IQueriesRepository
    {
        Task<IEnumerable<CategoriaDto>> GetAllCategorias();
        Task<CategoriaDto> GetCategoria(int categoriaId);
        Task<CategoriaDto> NombreCategoriaExiste(string nombreCategoria);
        Task<IEnumerable<CategoriaDto>> GetDropDownCategorias();
    }
}
