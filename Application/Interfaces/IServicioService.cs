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
    public interface IServicioService
    {
        public ServicioResponse GetServicioById(int IdServicio);
        public ServicioResponse CreateServicio(ServicioRequest servicioRequest);
        public ServicioResponse UpdateServicio(int idServicio, ServicioRequest servicioRequest);
        public ServicioResponse DeleteServicio(int IdServicio);
        public List<ServicioResponse> GetAllServicios();
    }
}
