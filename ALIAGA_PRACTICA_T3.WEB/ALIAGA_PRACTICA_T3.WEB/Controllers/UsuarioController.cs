using ALIAGA_PRACTICA_T3.WEB.Models;
using ALIAGA_PRACTICA_T3.WEB.Models.Entidades;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ALIAGA_PRACTICA_T3.WEB.Controllers
{
    public class UsuarioController : Controller
    {

        public T3Context cnx;

        public readonly IConfiguration configuration;


        public UsuarioController(T3Context cnx, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.cnx = cnx;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        
        
        [HttpPost]
        public ActionResult Login(string username, string passwd)
        {

            var user = cnx.Usuarios.Where(o => o.username == username && passwd == o.passwd).FirstOrDefault();
            if (user != null)
            {
                //Guardamos el claim
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Usuario");
            }

            return View();

        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string nombres,
            string direccion, string telefono,
            string correo, string username, string passwd)
        {
           var usuarios = cnx.Usuarios.ToList();
            Usuario u = new Usuario();

            if (cnx.Usuarios.Where(o=>o.correo == correo).FirstOrDefault() == null)
            {
                var usuario = new Usuario();
                usuario.nombres = nombres;
                usuario.direccion = direccion;
                usuario.telefono = telefono;
                usuario.correo = correo;
                usuario.username = username;
                usuario.passwd = passwd;
                cnx.Usuarios.Add(usuario);
                cnx.SaveChanges();

                return RedirectToAction("Login", "Usuario");   
            }
            if (cnx.Usuarios.Where(o => o.username == username).FirstOrDefault() == null)
            {
                var usuario = new Usuario();
                usuario.nombres = nombres;
                usuario.direccion = direccion;
                usuario.telefono = telefono;
                usuario.correo = correo;
                usuario.username = username;
                usuario.passwd = passwd;
                cnx.Usuarios.Add(usuario);
                cnx.SaveChanges();

                return RedirectToAction("Login", "Usuario");
            }

            return View();
        }

        [HttpGet]
        public ActionResult CreateMascota()
        {


            return View();
        }

        [HttpPost]
        public ActionResult CreateMascota(DateTime fechaNac,
            string sexo, string especie, string raza, 
            string tamanio, string particularidades, string nombre)
        {
            //idUsuario need claim
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = cnx.Usuarios.Where(o => o.username == claim.Value).Include(o => o.mascotas).FirstOrDefault();
            ViewBag.User = user;

            Mascota m = new Mascota();

            m.fechaNac = fechaNac;
            m.sexo = sexo;
            m.especie = especie;
            m.raza = raza;
            m.tamanio = tamanio;
            m.particularidades = particularidades;
            m.idUsuario = user.idUsuario;
            m.nombre = nombre;

            cnx.Mascotas.Add(m);
            cnx.SaveChanges();

            return RedirectToAction("Mascotas","Usuario");
        }



        [HttpGet]
        public ActionResult CreateHistoria()
        {
            //idUsuario need claim
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = cnx.Usuarios.Where(o => o.username == claim.Value).Include(o => o.mascotas).FirstOrDefault();
            ViewBag.User = user;

            var usuario = cnx.Usuarios.Where(o => o.idUsuario == user.idUsuario).Include(o => o.mascotas).FirstOrDefault();
            ViewBag.Mascotas = usuario.mascotas.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateHistoria(int idMascota)
        {
            //idUsuario need claim
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = cnx.Usuarios.Where(o => o.username == claim.Value).Include(o => o.mascotas).FirstOrDefault();
            ViewBag.User = user;

            Historia h = new Historia();

            h.codigo = "COD-" + user.username + "-" + DateTime.Now.ToShortDateString();
            h.fechaRegistro = DateTime.Now;
            h.idUsuario = user.idUsuario;
            h.idMascota = idMascota; 

            cnx.Historias.Add(h);
            cnx.SaveChanges();

            return RedirectToAction("Index", "Usuario");
        }



        [HttpGet]
        public ActionResult Mascotas()
        {

            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = cnx.Usuarios.Where(o => o.username == claim.Value).Include(o=>o.mascotas).FirstOrDefault();
            ViewBag.User = user;

            ViewBag.Mascotas = cnx.Mascotas.Where(o=>o.idUsuario == user.idUsuario).ToList();



            return View();
        }


       
     



        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = cnx.Usuarios.Where(o => o.username == claim.Value).Include(o => o.mascotas).FirstOrDefault();
            ViewBag.User = user;
            ViewBag.Usuario = cnx.Usuarios.Include("historias.mascota").Include(o => o.mascotas)
                .Where(o => o.idUsuario == user.idUsuario).FirstOrDefault();

            return View();
        }




    }
}
