using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ViajeServicio
    {
        public int ViajeServicioId { get; set; }
        public int ViajeId { get; set; }
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}
