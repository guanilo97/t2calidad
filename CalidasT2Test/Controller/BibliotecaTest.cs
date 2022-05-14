using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidasT2Test.Controller
{
    class BibliotecaTest
    {
        [Test]
        public void Caso1_MostrarTodosLosLibros()
        {

            var Mockrepo = new Mock<IBibliotecaRepositorio>();
            Mockrepo.Setup(o => o.GetBibliotecas(1)).Returns(new List<Biblioteca>());
            Mockrepo.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 });

            var controller = new BibliotecaController(null,null);
            var view = controller.Index() as ViewResult;
            Assert.AreEqual("Index", view.ViewName);
        }
    }
}
