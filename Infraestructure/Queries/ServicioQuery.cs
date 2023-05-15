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
    public class ServicioQuery : IServicioQuery
    {
        private readonly ServiciosContext _context;
        public ServicioQuery(ServiciosContext context)
        {
            _context = context;
        }
        public List<Servicio> GetAllServicios()
        {
            try
            {
                return _context.Servicio.ToList();
            }
            catch (DbUpdateException ex)
            {
                throw new Conflict("Error en solicitar a la base", ex);
            }
        }

        public Servicio GetServicioById(int idServicio)
        {
            try
            {
                Servicio unServicio = _context.Servicio
                    .Include(s => s.ViajeServicios)
                    .Single(x => x.ServicioId == idServicio);
                return unServicio;
            }
            catch (DbUpdateException ex)
            {
                throw new Conflict("Error en solicitar a la base", ex);
            }
        }
    }
}
