using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class ServicioResponse
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Disponibilidad { get; set; }
        public int Precio { get; set; }
    }
}
