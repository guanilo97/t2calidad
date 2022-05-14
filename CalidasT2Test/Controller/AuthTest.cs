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
    class AuthTest
    {
        [Test]
        public void Caso1_InicioSesionBien()
        {
            var controller = new AuthController(null, null);
            var vista = controller.Login() as ViewResult;
            Assert.AreEqual("Login", vista.ViewName);
        }
        [Test]
        public void Caso2_InicioSesionMal()
        {
            var Mockrepository = new Mock<IAuthRepositorio>();
            Mockrepository.Setup(o => o.Obtener(null, null)).Returns(new Usuario());

            var controller = new AuthController(null,null);
            var view = controller.Login("Hola", "Mundo") as ViewResult;

            Assert.AreEqual("Login", false);
        }
        [Test]
        public void Caso3_LogueadoExitoso()
        {
            var Mockrepository = new Mock<IAuthRepositorio>();

            var controller = new AuthController(null, null);
            var view = controller.Logout() as RedirectToActionResult;

            Assert.AreEqual("Login", view.ActionName);
        }
    }
}
