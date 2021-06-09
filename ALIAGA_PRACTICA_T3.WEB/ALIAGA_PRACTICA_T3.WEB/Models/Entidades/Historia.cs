using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALIAGA_PRACTICA_T3.WEB.Models.Entidades
{
    public class Historia
    {
        public int idHistoria { get; set; }
        public string codigo { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idUsuario { get; set; }
        public int idMascota { get; set; }

        

        public Mascota mascota { get; set; }
        public Usuario usuario { get; set; }
    }
}
