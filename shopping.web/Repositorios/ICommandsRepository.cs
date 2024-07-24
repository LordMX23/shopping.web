using shopping.web.DTOs;
using shopping.web.Interfaces.Common;

namespace shopping.web.Repositorios
{
    public interface ICommandsRepository : IUnitOfWork
    {
        Task<CategoriaDto> CreaCategoria(CategoriaDto categoriaDto);
        Task<CategoriaDto> ActualizarCategoria(int categoriaId, CategoriaDto categoriaDto);
        Task<CategoriaDto> BorrarCategoria(int categoriaId);
    }
}
