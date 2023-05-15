using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IViajeServicioQuery
    {
        public ViajeServicio GetViajeServicioById(int IdViajeServicio);
        public List<ViajeServicio> GetAllViajeServicios();
    }
}
