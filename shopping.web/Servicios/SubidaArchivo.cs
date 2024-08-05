using Microsoft.AspNetCore.Components.Forms;
using shopping.web.Data;

namespace shopping.web.Servicios
{
    public class SubidaArchivo : ISubidaArchivo
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public SubidaArchivo(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public bool BorrarArchivo(string nombreArchivo)
        {
            try
            {
                var Path = $"{_webHostEnvironment.WebRootPath}\\{nombreArchivo}";
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> SubirArchivo(IBrowserFile archivo)
        {
            try
            {
                FileInfo FileInfo = new FileInfo(archivo.Name);
                var FileName = Guid.NewGuid().ToString() + FileInfo.Extension;
                var FolderDirectory = $"{_webHostEnvironment.WebRootPath}\\ImagenesArticulos";
                var MiPath = Path.Combine(_webHostEnvironment.WebRootPath, "ImagenesArticulos", FileName);

                var MemoryStream = new MemoryStream();
                await archivo.OpenReadStream().CopyToAsync(MemoryStream);

                if (!Directory.Exists(FolderDirectory)) Directory.CreateDirectory(FolderDirectory);

                await using (var fs = new FileStream(MiPath, FileMode.Create, FileAccess.Write))
                {
                    MemoryStream.WriteTo(fs);
                }

                var URL = $"{_configuration.GetValue<string>("ServerUrl")}";
                var FullPath = $"{URL}/ImagenesArticulos/{FileName}";
                return FullPath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
