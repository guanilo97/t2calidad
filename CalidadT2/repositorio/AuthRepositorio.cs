using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.repositorio
{
    public interface IAuthRepositorio
    {
        Usuario Obtener(string nombreusario, string contrasenia);
    }
    public class AuthRepositorio : IAuthRepositorio
    {
        private AppBibliotecaContext _app;
        public AuthRepositorio(AppBibliotecaContext app)
        {
            _app = app;
        }
        public Usuario Obtener(string nombreusario, string contrasenia)
        {
            var usuario = _app.Usuarios.Where(o => o.Username == nombreusario && o.Password == contrasenia).FirstOrDefault();
            return usuario;
        }
    }
}
