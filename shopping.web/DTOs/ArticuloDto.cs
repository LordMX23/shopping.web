using Humanizer;
using shopping.web.Modelos;
using System.ComponentModel.DataAnnotations;

namespace shopping.web.DTOs
{
    public class ArticuloDto
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(30, MinimumLength =5, ErrorMessage ="El nombre debe de estar entre 5 y 30 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(300, MinimumLength = 20, ErrorMessage = "La descripcion debe de estar entre 20 y 300 caracteres.")]
        public string Descripcion { get; set; }
        public string Caracteristicas { get; set; }

        [Required(ErrorMessage = "El contacto es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El contacto debe de estar entre 30 y 50 caracteres.")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "El numero de contacto es obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El numero de contacto es de 10 digitos.")]
        public string ContactoTelefono { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public double Precio { get; set; }
        [Required]
        public bool Activo { get; set; }

        // Relacion con Modelo Categoria
        public int CategoriaId { get; set; }




        public static implicit operator Articulo(ArticuloDto dto)
        {
            Articulo ArticuloDto = new Articulo()
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
            };

            return ArticuloDto;
        }
    }
}
