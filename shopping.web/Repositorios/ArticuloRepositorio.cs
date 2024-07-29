using Microsoft.EntityFrameworkCore;
using shopping.web.Data;
using shopping.web.DTOs;
using shopping.web.Interfaces;
using shopping.web.Modelos;

namespace shopping.web.Repositorios
{
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private readonly ApplicationDbContext _bd;

        public ArticuloRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public async Task<ArticuloDto> ActualizarArticulo(int articuloId, ArticuloDto articuloDto)
        {
            try
            {
                if (articuloId == articuloDto.ArticuloId)
                {
                    Articulo Articulo = await _bd.Articulo.FindAsync(articuloId);

                    Articulo.Nombre = articuloDto.Nombre;
                    Articulo.Descripcion = articuloDto.Descripcion;
                    Articulo.Caracteristicas = articuloDto.Caracteristicas;
                    Articulo.Contacto = articuloDto.Contacto;
                    Articulo.ContactoTelefono = articuloDto.ContactoTelefono;
                    Articulo.Precio = articuloDto.Precio;
                    Articulo.Activo = articuloDto.Activo;
                    Articulo.FechaActualizacion = DateTime.Now;

                    _bd.Articulo.Update(Articulo);
                    await _bd.SaveChangesAsync();
                    return Articulo;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<int> BorrarArticulo(int articuloId)
        {
            Articulo Articulo = await _bd.Articulo.FindAsync(articuloId);
            if (Articulo != null)
            {
                _bd.Articulo.Remove(Articulo);
                await _bd.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ArticuloDto> CreaArticulo(ArticuloDto articuloDto)
        {
            Articulo Articulo = articuloDto;
            Articulo.FechaCreacion = DateTime.Now;
            await _bd.Articulo.AddAsync(Articulo);
            await _bd.SaveChangesAsync();
            return Articulo;
        }

        public async Task<IEnumerable<ArticuloDto>> GetAllArticulo()
        {
            IEnumerable<Articulo> Articulo = _bd.Articulo;

            List<ArticuloDto> ArticuloDtos = new List<ArticuloDto>();
            foreach (Articulo item in Articulo)
            {
                ArticuloDto MiArticulo = new ArticuloDto()
                {
                    ArticuloId = item.ArticuloId,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion,
                    Caracteristicas = item.Caracteristicas,
                    Contacto = item.Contacto,
                    ContactoTelefono = item.ContactoTelefono,
                    Precio = item.Precio,
                    Activo = item.Activo,
                    CategoriaId = item.CategoriaId,
                };
                ArticuloDtos.Add(MiArticulo);
            }

            return ArticuloDtos as IEnumerable<ArticuloDto>;
        }

        public async Task<ArticuloDto> GetArticulo(int articuloId)
        {
            Articulo Articulo = await _bd.Articulo.FirstOrDefaultAsync(c => c.ArticuloId == articuloId);

            if (Articulo == null)
            {
                return null;
            }
            return Articulo;
        }
    }
}
