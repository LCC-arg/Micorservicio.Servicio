using Domain.Entities;

namespace Application.Interfaces
{
    public interface IServicioQuery
    {
        public Servicio GetServicioById(int idServicio);
        public List<Servicio> GetAllServicios();
    }
}
