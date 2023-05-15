using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class ServicioRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Disponibilidad { get; set; }
        public int Precio { get; set; }
    }
}
