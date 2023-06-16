using Domain.Entities;

namespace Application.Interfaces
{
    public interface IViajeServicioCommand
    {
        public ViajeServicio InsertViajeServicio(ViajeServicio unViajeServicio);
        public ViajeServicio ModifyViajeServicio(int idViajeServicio, ViajeServicio viajeServicio);
        public ViajeServicio DeleteViajeServicio(int idViajeServicio);
    }
}
