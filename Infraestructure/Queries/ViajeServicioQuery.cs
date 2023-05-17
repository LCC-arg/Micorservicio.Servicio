using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Queries
{
    public class ViajeServicioQuery : IViajeServicioQuery
    {
        private readonly ServiciosContext _context;
        public ViajeServicioQuery(ServiciosContext context)
        {
            _context = context;
        }

        public List<ViajeServicio> GetAllViajeServicios()
        {
            try
            {
                return _context.ViajeServicios.ToList();
            }
            catch (DbUpdateException)
            {
                throw new ExceptionNotFound("No existen Viaje Servicio");
            }
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
