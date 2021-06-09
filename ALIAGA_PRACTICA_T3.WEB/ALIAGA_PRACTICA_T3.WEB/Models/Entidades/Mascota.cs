using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALIAGA_PRACTICA_T3.WEB.Models.Entidades
{
    public class Mascota
    {
        public int idMascota { get; set; }
        public DateTime fechaNac { get; set; }
        public string sexo { get; set; }
        public string especie { get; set; }
        public string raza { get; set; }
        public string tamanio { get; set; }
        public string particularidades { get; set; }
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public Usuario usuario { get; set; }
    }
}
