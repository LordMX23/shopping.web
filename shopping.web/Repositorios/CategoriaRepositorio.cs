using Microsoft.EntityFrameworkCore;
using shopping.web.Data;
using shopping.web.DTOs;
using shopping.web.Interfaces;
using shopping.web.Modelos;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace shopping.web.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _bd;

        public CategoriaRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public async Task<CategoriaDto> ActualizarCategoria(int categoriaId, CategoriaDto categoriaDto)
        {
            try
            {
                if (categoriaId == categoriaDto.CategoriaId)
                {
                    Categoria Categoria = await _bd.Categoria.FindAsync(categoriaId);
                    
                    Categoria.Descripcion = categoriaDto.Descripcion;
                    Categoria.NombreCategoria = categoriaDto.NombreCategoria;
                    Categoria.FechaActualizacion = DateTime.Now;

                    _bd.Categoria.Update(Categoria);
                    await _bd.SaveChangesAsync();
                    return Categoria;


                    //Categoria Categoria = categoriaDto;
                    //Categoria.FechaActualizacion = DateTime.Now;
                    //var CategoriaActualizada = _bd.Categoria.Update(Categoria);
                    //await _bd.SaveChangesAsync();
                    //return Categoria;

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

        public async Task<CategoriaDto> BorrarCategoria(int categoriaId)
        {
            Categoria Categoria = await _bd.Categoria.FindAsync(categoriaId);
            if(Categoria != null)
            {
                _bd.Categoria.Remove(Categoria);
                await _bd.SaveChangesAsync();
            }
            return Categoria;
        }

        public async Task<CategoriaDto> CreaCategoria(CategoriaDto categoriaDto)
        {
            Categoria Categoria = categoriaDto;
            Categoria.FechaCreacion = DateTime.Now;
            await _bd.Categoria.AddAsync(Categoria);
            await _bd.SaveChangesAsync();
            return Categoria;
        }

        public async Task<IEnumerable<CategoriaDto>> GetAllCategorias()
        {
            IEnumerable<Categoria> Categoria = _bd.Categoria;
            
            List<CategoriaDto> CategoriaDtos = new List<CategoriaDto>();
            foreach (Categoria item in Categoria)
            {
                CategoriaDto MiCategoria = new CategoriaDto()
                {
                    CategoriaId = item.CategoriaId,
                    NombreCategoria = item.NombreCategoria,
                    Descripcion = item.Descripcion
                };
                CategoriaDtos.Add(MiCategoria);
            }
            //IEnumerable<CategoriaDto> enumerable = CategoriaDtos;

            return CategoriaDtos as IEnumerable<CategoriaDto>;
        }

        public async Task<CategoriaDto> GetCategoria(int categoriaId)
        {
            Categoria Categoria = await _bd.Categoria.FirstOrDefaultAsync(c => c.CategoriaId == categoriaId);

            if (Categoria == null)
            {
                return null;
            }
            return Categoria;
        }

        public async Task<IEnumerable<DropDownCategoriaDto>> GetDropDownCategorias()
        {
            IEnumerable<Categoria> Categoria = _bd.Categoria;

            List<DropDownCategoriaDto> DDCategoriaDtos = new List<DropDownCategoriaDto>();
            foreach (Categoria item in Categoria)
            {
                DropDownCategoriaDto MiCategoria = new DropDownCategoriaDto()
                {
                    CategoriaId = item.CategoriaId,
                    NombreCategoria = item.NombreCategoria,
                };
                DDCategoriaDtos.Add(MiCategoria);
            }

            return DDCategoriaDtos as IEnumerable<DropDownCategoriaDto>;
        }

        public async Task<CategoriaDto> NombreCategoriaExiste(string nombreCategoria)
        {
            Categoria Categoria = Categoria = await _bd.Categoria.FirstOrDefaultAsync(c => c.NombreCategoria.ToLower() == nombreCategoria.ToLower());

            if (Categoria == null)
            {
                return null;
            }
            return Categoria;
        }
    }
}
