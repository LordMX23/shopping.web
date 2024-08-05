using Microsoft.AspNetCore.Components.Forms;

namespace shopping.web.Servicios
{
    public interface ISubidaArchivo
    {
        Task<string> SubirArchivo(IBrowserFile archivo);
        bool BorrarArchivo(string nombreArchivo);
    }
}
