using shopping.web.DTOs;
using System.ComponentModel.DataAnnotations;

namespace shopping.web.Modelos
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        public string NombreCategoria { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }

        public virtual ICollection<Articulo> Articulo { get; set; }

        public static implicit operator CategoriaDto(Categoria dto)
        {
            CategoriaDto CategoriaDto = new CategoriaDto()
            {
                CategoriaId = dto.CategoriaId,
                NombreCategoria = dto.NombreCategoria,
                Descripcion = dto.Descripcion

            };
            return CategoriaDto;
        }

        public static implicit operator DropDownCategoriaDto(Categoria dto)
        {
            DropDownCategoriaDto CategoriaDto = new DropDownCategoriaDto()
            {
                CategoriaId = dto.CategoriaId,
                NombreCategoria = dto.NombreCategoria,

            };
            return CategoriaDto;
        }
    }
}
