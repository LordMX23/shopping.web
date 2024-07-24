using shopping.web.Modelos;
using System.ComponentModel.DataAnnotations;

namespace shopping.web.DTOs
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string NombreCategoria { get; set; }

        public string Descripcion { get; set; }

        public static implicit operator Categoria(CategoriaDto dto)
        {
            Categoria Categoria = new Categoria()
            {
                CategoriaId = dto.CategoriaId,
                NombreCategoria = dto.NombreCategoria,
                Descripcion = dto.Descripcion

            };
            return Categoria;
        }
    }
}
