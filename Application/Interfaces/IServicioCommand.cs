using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServicioCommand
    {
        public Servicio InsertServicio(Servicio servicio);
        public Servicio ModifyServicio(int idServicio, Servicio servicio);
        public Servicio DeleteServicio(int idServicio);
    }
}
