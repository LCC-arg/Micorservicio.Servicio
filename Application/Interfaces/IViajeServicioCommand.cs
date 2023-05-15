using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IViajeServicioCommand
    {
        public ViajeServicio InsertViajeServicio(ViajeServicio unViajeServicio);
        public ViajeServicio ModifyViajeServicio(int idViajeServicio, ViajeServicio viajeServicio);
        public ViajeServicio DeleteViajeServicio(int idViajeServicio);
    }
}
