using Domain.Entities;

namespace Application.Interfaces
{
    public interface IServicioCommand
    {
        public Servicio InsertServicio(Servicio servicio);
        public Servicio ModifyServicio(int idServicio, Servicio servicio);
        public Servicio DeleteServicio(int idServicio);
    }
}
