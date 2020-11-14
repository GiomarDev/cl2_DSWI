using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL2.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CL2.Controllers
{
    public class LibroController : Controller
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

        List<Libro> listLibro()
        {
            List<Libro> aLibro = new List<Libro>();
            SqlCommand cmd = new SqlCommand("SP_LISTALIBRO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aLibro.Add(new Libro()
                {
                    codigo = int.Parse(dr[0].ToString()),
                    autor = dr[1].ToString(),
                    titulo = dr[2].ToString(),
                    editorial = dr[3].ToString(),
                    costo = double.Parse(dr[4].ToString()),
                    cantidad = int.Parse(dr[5].ToString()),
                    foto = dr[6].ToString()
                });
            }
            dr.Close();
            cn.Close();
            return aLibro;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult carritoCompras()
        {
            if (Session["carrito"] == null)
            {
                Session["carrito"] = new List<Item>();
            }
            return View(listLibro());
        }

        public ActionResult seleccionarProducto(int id)
        {
            Libro objL = listLibro().Where(p => p.codigo == id).FirstOrDefault();
            return View(objL);

        }
        public ActionResult agregaLibro(int id, int cant = 0)
        {
            var miLibro = listLibro().Where(p => p.codigo == id).FirstOrDefault();
            Item objI = new Item()
            {
                codigo = miLibro.codigo,
                titulo = miLibro.titulo,
                costo = miLibro.costo,
                cantidad= cant,
                foto=miLibro.foto
            };

            var miCarrito = (List<Item>)Session["carrito"];
            miCarrito.Add(objI);
            Session["carrito"]=miCarrito;
            return RedirectToAction("carritoCompras");
        }
        public ActionResult comprar()
        {
            if (Session["carrito"] == null)
            {
                return RedirectToAction("carritoCompras");
            }
            var miCarrito = (List<Item>)Session["carrito"];
            ViewBag.total = miCarrito.Sum(i => i.subTotal);
            return View(miCarrito);
        }
        public ActionResult eliminarLibro(int id)
        {
            //Descargar los datos del Carrito
            var miCarrito = (List<Item>)Session["carrito"];
            var miLibro = miCarrito.Where(i => i.codigo == id).FirstOrDefault();
            miCarrito.Remove(miLibro);

            //Actualizar el Carrito con los nuevos Registros
            Session["carrito"] = miCarrito;
            return RedirectToAction("comprar");
        }
        public ActionResult pagoLibro()
        {
            List<Item> detalle = (List<Item>)Session["carrito"];
            double total = 0;
            foreach (Item i in detalle)
            {
                total += i.subTotal;
            }
            ViewBag.total = total;
            return View(detalle);
        }
        public ActionResult finalizarVenta(string dni, string nom)
        {
            ViewBag.dni = dni;
            ViewBag.nom = nom;
            List<Item> detalle = (List<Item>)Session["carrito"];
            double total = 0;
            foreach (Item i in detalle)
            {
                total += i.subTotal;
            }
            ViewBag.total = total;
            return View();
        }

    }
}