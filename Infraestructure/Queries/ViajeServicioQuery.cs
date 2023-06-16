using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Queries
{
    public class ViajeServicioQuery : IViajeServicioQuery
    {
        private readonly ServiciosContext _context;
        public ViajeServicioQuery(ServiciosContext context)
        {
            _context = context;
        }

        public List<ViajeServicio> GetAllViajeServicios(int viajeId)
        {
            var viajeServicios = _context.ViajeServicios.ToList();

            if (viajeId != 0)
            {
                viajeServicios = viajeServicios.Where(vc => vc.ViajeId == viajeId).ToList();
            }

            return viajeServicios;
        }


        public ViajeServicio GetViajeServicioById(int IdViajeServicio)
        {
            try
            {
                ViajeServicio unViajeServicio = _context.ViajeServicios.SingleOrDefault(x => x.ViajeServicioId == IdViajeServicio);
                return unViajeServicio;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionNotFound("No se encontró el viaje servicio solicitado");
            }
        }
    }
}
