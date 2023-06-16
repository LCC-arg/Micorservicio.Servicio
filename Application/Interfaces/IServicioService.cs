using Application.Requests;
using Application.responses;
using Application.Responses;

namespace Application.Interfaces
{
    public interface IServicioService
    {

        public ServicioResponse CreateServicio(ServicioRequest servicioRequest);
        public ServicioResponse UpdateServicio(int idServicio, ServicioRequest servicioRequest);
        public ServicioResponse DeleteServicio(int IdServicio);
        public GetServicioResponse GetServicioById(int IdServicio);
        public List<ServicioResponse> GetAllServicios();
    }
}
