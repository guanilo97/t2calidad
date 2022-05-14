using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.repositorio
{
    public interface IBibliotecaRepositorio
    {
        List<Biblioteca> GetBibliotecas(int Id);
        Biblioteca Bibliotec(int libroId, int Id);

        void AgregarBiblioteca(int libro, int Id);

        void Leer(Biblioteca bibliotec);
        Usuario LoggedUser();

        void Culminado(Biblioteca bibliotec);
    }
    }
    public class BibliotecaRepositorio : IBibliotecaRepositorio
    {
        private AppBibliotecaContext _app;
        public BibliotecaRepositorio(AppBibliotecaContext app)
        {
            _app = app;
        }
    public void AgregarBiblioteca(int libro, int Id)
    {
        var biblioteca = new Biblioteca
        {
            LibroId = libro,
            UsuarioId = Id,
            Estado = ESTADO.POR_LEER
        };

        _app.Bibliotecas.Add(biblioteca);
        _app.SaveChanges();
    }

    public List<Biblioteca> GetBibliotecas(int Id)
    {
        var model = _app.Bibliotecas
            .Include(o => o.Libro.Autor)
            .Include(o => o.Usuario)
            .Where(o => o.UsuarioId == Id)
            .ToList();

        return model;
    }

    public void Leer(Biblioteca bibliotec)
    {
        bibliotec.Estado = ESTADO.LEYENDO;
        _app.SaveChanges();
    }

    public void Culminado(Biblioteca bibliotec)
    {
        bibliotec.Estado = ESTADO.LEYENDO;
        _app.SaveChanges();
    }

    public Biblioteca Bibliotec(int libroId, int Id)
    {
        var libro = _app.Bibliotecas
            .Where(o => o.LibroId == libroId && o.UsuarioId == Id)
            .FirstOrDefault();
        return libro;
    }

}
