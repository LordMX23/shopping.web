using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using shopping.web.DTOs;
using shopping.web.Helpers;

namespace shopping.web.Pages.Articulos
{
    public partial class CompEditarArticulo
    {
        [Parameter]
        public int? Id { get; set; }
        private ArticuloDto ArticuloDto { get; set; } = new ArticuloDto(); // Definimos el modelo
        private DropDownCategoriaDto categoriaSeleccionada = new DropDownCategoriaDto();
        private bool EstaIniciadoSubidaImagen { get; set; } = false;
        private IEnumerable<DropDownCategoriaDto> DropDownCategoriaDtos { get; set; } = new List<DropDownCategoriaDto>();   // Para obtener la lista de categorias
        private ImagenArticuloDto ImagenDto { get; set; } = new ImagenArticuloDto();
        private List<string> NombresImagenesBorradas { get; set; } = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            DropDownCategoriaDtos = await MyCategoriaReositorio.GetDropDownCategorias();

            if (Id != null)
            {
                ArticuloDto = await MyArticuloRepositorio.GetArticulo(Id.Value);
                if (ArticuloDto?.ImagenArticulo != null)
                {
                    ArticuloDto.UrlImagenes = ArticuloDto.ImagenArticulo.Select(u => u.UrlImagenArticulo).ToList();
                }
                categoriaSeleccionada.CategoriaId = ArticuloDto.CategoriaId;
            }
        }


        private async Task ManejadorOnEditarArticulo()
        {
            //Se obtiene el Id de la categoría, es decir CategoriaId del DropDown
            ArticuloDto.CategoriaId = categoriaSeleccionada.CategoriaId;

            // Actualiza el articulo con imagenes
            var ResultadoActualizarArticulo = await MyArticuloRepositorio.ActualizarArticulo(ArticuloDto.ArticuloId, ArticuloDto);

            if ((ArticuloDto.UrlImagenes != null && ArticuloDto.UrlImagenes.Any()) || (NombresImagenesBorradas != null && NombresImagenesBorradas.Any()))
            {
                if (NombresImagenesBorradas != null && NombresImagenesBorradas.Any())
                {
                    foreach (var nombreImagenBorrada in NombresImagenesBorradas)
                    {
                        var NombreImagen = nombreImagenBorrada.Replace($"{NavigationManager.BaseUri}ImagenesArticulos/", "");
                        var Resultado = SubidaArchivo.BorrarArchivo(NombreImagen);
                        await MyImagenArticuloRepositorio.BorrarArticuloImagenPorUrlImagen(nombreImagenBorrada);
                    }
                }

                await AgregarImagenesArticulo(ResultadoActualizarArticulo);
            }

            await JsRuntime.ToastrSuccess("Articulo actualizado correctamente");
            NavigationManager.NavigateTo("articulos");
        }

        private async Task ManejadorOnSubidaArchivo(InputFileChangeEventArgs e)
        {
            EstaIniciadoSubidaImagen = true;
            try
            {
                var Imagens = new List<string>();
                if (e.GetMultipleFiles().Count() > 0)
                {
                    foreach (var file in e.GetMultipleFiles())
                    {
                        System.IO.FileInfo FileInfo = new System.IO.FileInfo(file.Name);
                        if (FileInfo.Extension.ToLower() == ".jpg" || FileInfo.Extension.ToLower() == ".jpeg" || FileInfo.Extension.ToLower() == ".png")
                        {
                            var UploadedImagenPatch = await SubidaArchivo.SubirArchivo(file);
                            Imagens.Add(UploadedImagenPatch);
                        }
                        else
                        {
                            await JsRuntime.ToastrError("Por favor seleccione unicamente .jpg .jpeg .png");
                            return;
                        }
                    }

                    if (Imagens.Any())
                    {
                        if (ArticuloDto.UrlImagenes != null && ArticuloDto.UrlImagenes.Any())
                        {
                            ArticuloDto.UrlImagenes.AddRange(Imagens);
                        }
                        else
                        {
                            ArticuloDto.UrlImagenes = new List<string>();
                            ArticuloDto.UrlImagenes.AddRange(Imagens);
                        }
                    }
                    else
                    {
                        await JsRuntime.ToastrError("Fallo en la subida de imagenes");
                        return;
                    }
                }
                EstaIniciadoSubidaImagen = false;

            }
            catch (Exception ex)
            {
                EstaIniciadoSubidaImagen = false;
                throw;
            }
        }


        internal async Task BorrarImagen(string urlImagen)
        {
            try
            {
                var ImagenIndex = ArticuloDto.UrlImagenes.FindIndex(x => x == urlImagen);
                var NombreImagen = urlImagen.Replace($"{NavigationManager.BaseUri}ImagenesArticulos/", "");

                NombresImagenesBorradas ??= new List<string>();
                NombresImagenesBorradas.Add(urlImagen);


                ArticuloDto.UrlImagenes.RemoveAt(ImagenIndex);
            }
            catch (Exception ex)
            {

                await JsRuntime.ToastrError(ex.Message);
                return;
            }
        }

        private async Task AgregarImagenesArticulo(ArticuloDto dto)
        {
            foreach (var UrlImagen in ArticuloDto.UrlImagenes)
            {
                if (ArticuloDto.ImagenArticulo == null || ArticuloDto.ImagenArticulo.Where(x => x.UrlImagenArticulo == UrlImagen).Count() == 0)
                {
                    ImagenDto = new ImagenArticuloDto()
                    {
                        ArticuloId = dto.ArticuloId,
                        UrlImagenArticulo = UrlImagen,
                    };

                    await MyImagenArticuloRepositorio.CrearArticuloImagen(ImagenDto);
                }
            }
        }

    }
}