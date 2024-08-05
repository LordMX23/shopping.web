using shopping.web.Modelos;

namespace shopping.web.DTOs
{
    public class ImagenArticuloDto
    {
        public int ImagenArticuloId { get; set; }
        public int ArticuloId { get; set; }
        public string UrlImagenArticulo { get; set; }

        public static implicit operator ImagenArticulo(ImagenArticuloDto dto)
        {
            ImagenArticulo ImagenArticulo = new ImagenArticulo()
            {
                ImagenArticuloId = dto.ImagenArticuloId,
                ArticuloId = dto.ArticuloId,
                UrlImagenArticulo = dto.UrlImagenArticulo
            };

            return ImagenArticulo;
        }
    }
}
