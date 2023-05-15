using Application.Requests;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IViajeServicioService
    {
        public ViajeServicioResponse GetViajeServicioById(int idViajeServicio);
        public ViajeServicioResponse CreateViajeServicio(ViajeServicioRequest viajeServicioRequest);
        public ViajeServicioResponse UpdateViajeServicio(int idViajeServicio, ViajeServicioRequest viajeServicioRequest);
        public ViajeServicioResponse DeleteViajeServicio(int idViajeServicio);
        public List<ViajeServicioResponse> GetAllViajesServicio();
    }
}
