using Microsoft.EntityFrameworkCore;
using shopping.web.Data;
using shopping.web.DTOs;
using shopping.web.Interfaces;
using shopping.web.Modelos;

namespace shopping.web.Repositorios
{
    public class ImagenArticuloRepositorio : IImagenArticuloRepositorio
    {
        private readonly ApplicationDbContext _bd;

        public ImagenArticuloRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public async Task<int> BorrarArticuloImagenPorArticuloId(int articuloId)
        {
            var ListaImagenes = await _bd.ImagenArticulo.Where(x => x.ArticuloId == articuloId).ToListAsync();
            _bd.ImagenArticulo.RemoveRange(ListaImagenes);
            return await _bd.SaveChangesAsync();
        }

        public async Task<int> BorrarArticuloImagenPorImagenId(int imagenId)
        {
            var imagen = await _bd.ImagenArticulo.FindAsync(imagenId);
            _bd.ImagenArticulo.Remove(imagen);
            return await _bd.SaveChangesAsync();
            
        }

        public async Task<int> BorrarArticuloImagenPorUrlImagen(string urlImagen)
        {
            var Imagen = await _bd.ImagenArticulo.FirstOrDefaultAsync(x => x.UrlImagenArticulo.ToLower() == urlImagen.ToLower());
            if(Imagen == null) return 0;

            _bd.ImagenArticulo.Remove(Imagen);
            return await _bd.SaveChangesAsync();
        }

        public async Task<int> CrearArticuloImagen(ImagenArticuloDto imagenArticuloDto)
        {
            var Imagen = imagenArticuloDto;
            await _bd.ImagenArticulo.AddAsync(Imagen);
            return await _bd.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImagenArticuloDto>> GetImagenesArticulo(int articuloId)
        {
            IEnumerable<ImagenArticulo> ImagenArticulo = await _bd.ImagenArticulo.Where(x => x.ArticuloId == articuloId).ToListAsync();
            return ImagenArticulo as IEnumerable<ImagenArticuloDto>; ;
        }
    }
}
