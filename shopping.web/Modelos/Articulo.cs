using Microsoft.JSInterop.Infrastructure;
using shopping.web.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping.web.Modelos
{
    public class Articulo
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string Caracteristicas { get; set; }
        [Required]
        public string Contacto { get; set; }
        [Required]
        public string ContactoTelefono { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }

        // Relacion con Modelo Categoria
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        // Relacion cin ImagenArticulo
        public virtual ICollection<ImagenArticulo> ImagenArticulo { get; set; }



        public static implicit operator ArticuloDto(Articulo dto)
        {
            if (dto == null) return null;

            List<string> UrlImagenes = new List<string>();

            if (dto.ImagenArticulo != null && dto.ImagenArticulo.Count > 0)
            {
                foreach (var item in dto.ImagenArticulo)
                {
                    UrlImagenes.Add(item.UrlImagenArticulo);
                }
            }

            ArticuloDto Articulo = new ArticuloDto()
            {
                ArticuloId = dto.ArticuloId,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Caracteristicas = dto.Caracteristicas,
                Contacto = dto.Contacto,
                ContactoTelefono = dto.ContactoTelefono,
                Precio = dto.Precio,
                Activo = dto.Activo,
                CategoriaId = dto.CategoriaId,
                UrlImagenes = UrlImagenes,
            };


            return Articulo;
        }

    }
}
