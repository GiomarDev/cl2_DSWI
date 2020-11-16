using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using waAutorClient.ServiceReference1;
namespace waAutorClient.Controllers
{
    public class AutorController : Controller
    {
        ServiceAutorClient miServicio = new ServiceAutorClient();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listadoAutores() 
        {
            return View(miServicio.listadoAutores());
        }

        public ActionResult nuevoAutor()
        {
            ViewBag.pais = new SelectList(miServicio.listadoPais(), "codigo", "nombre");
            ViewBag.codigoNuevo = miServicio.listadoAutoresO().Last().codigo + 1;
            return View(new AutorO());
        }
        [HttpPost]
        public ActionResult nuevoAutor(AutorO objA)
        {
            ViewBag.mensaje = miServicio.nuevoAutor(objA);
            ViewBag.pais = new SelectList(miServicio.listadoPais(), "codigo", "nombre");
            ViewBag.codigoNuevo = miServicio.listadoAutoresO().Last().codigo;
            return View(objA);
        }

        public ActionResult actualizaAutor(int id)
        {
            AutorO objA = miServicio.listadoAutoresO().Where(a => a.codigo == id).FirstOrDefault();
            ViewBag.pais = new SelectList(miServicio.listadoPais(), "codigo", "nombre",objA.pais);
            return View(objA);
        }
        [HttpPost]
        public ActionResult actualizaAutor(AutorO objA)
        {
            ViewBag.mensaje = miServicio.actualizaAutor(objA);
            ViewBag.pais = new SelectList(miServicio.listadoPais(), "codigo", "nombre",objA.pais);
            return View(objA);
        }

        public ActionResult detalleAutor(int id)
        {
            Autor objA = miServicio.listadoAutores().Where(a => a.codigo == id).FirstOrDefault();
            return View(objA);
        }

        public ActionResult eliminaAutor(int id)
        {
            AutorO objA = miServicio.listadoAutoresO().Where(a => a.codigo == id).FirstOrDefault();
            miServicio.eliminaAutor(objA);
            return RedirectToAction("listadoAutores");
        }
    }
}