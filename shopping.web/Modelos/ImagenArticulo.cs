using shopping.web.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping.web.Modelos
{
    public class ImagenArticulo
    {
        [Key]
        public int ImagenArticuloId { get; set; }
        public int ArticuloId { get; set; }
        public string UrlImagenArticulo { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulo Articulo { get; set; }

        public static implicit operator ImagenArticuloDto(ImagenArticulo dto)
        {
            ImagenArticuloDto ImagenArticuloDto = new ImagenArticuloDto()
            {
                ImagenArticuloId = dto.ImagenArticuloId,
                ArticuloId = dto.ArticuloId,
                UrlImagenArticulo = dto.UrlImagenArticulo
            };

            return ImagenArticuloDto;
        }
    }
}
