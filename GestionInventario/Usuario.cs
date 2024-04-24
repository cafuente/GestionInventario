using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public int IdPerfil { get; set; }
    }
}
