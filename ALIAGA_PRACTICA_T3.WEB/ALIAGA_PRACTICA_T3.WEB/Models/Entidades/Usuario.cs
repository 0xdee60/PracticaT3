using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALIAGA_PRACTICA_T3.WEB.Models.Entidades
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombres { get; set; }
        public string direccion{ get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string username { get; set; }
        public string passwd { get; set; }


        public List<Historia> historias { get; set; }
        public List<Mascota> mascotas { get; set; }
    }
}
