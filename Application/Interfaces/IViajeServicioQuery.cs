using Domain.Entities;

namespace Application.Interfaces
{
    public interface IViajeServicioQuery
    {
        public ViajeServicio GetViajeServicioById(int IdViajeServicio);
        public List<ViajeServicio> GetAllViajeServicios(int viajeId);
    }
}
