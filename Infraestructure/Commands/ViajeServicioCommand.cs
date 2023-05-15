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

namespace Infraestructure.Commands
{
    public class ViajeServicioCommand : IViajeServicioCommand
    {
        private readonly ServiciosContext _context;

        public ViajeServicioCommand(ServiciosContext context)
        {
            _context = context;
        }

        public ViajeServicio DeleteViajeServicio(int idViajeServicio)
        {
            try
            {
                ViajeServicio unViajeServicio = _context.ViajeServicios.SingleOrDefault(x => x.ViajeServicioId == idViajeServicio);
                if (unViajeServicio != null)
                {
                    _context.Remove(unViajeServicio);
                    _context.SaveChanges();
                }
                return unViajeServicio;
            }
            catch (DbUpdateException ex)
            {
                throw new Conflict("Error en borrar el servicio de la base de datos", ex);
            }
        }

        public ViajeServicio InsertViajeServicio(ViajeServicio unViajeServicio)
        {
            try
            {
                _context.Add(unViajeServicio);
                _context.SaveChanges();
                return unViajeServicio;
            }
            catch (DbUpdateException ex)
            {

                throw new Conflict("Error en la inserción a la base de datos", ex);
            }
        }

        public ViajeServicio ModifyViajeServicio(int idViajeServicio, ViajeServicio viajeServicio)
        {

            try
            {
                var ViajeServicioToUpdate = _context.ViajeServicios.FirstOrDefault(s => s.ViajeServicioId == idViajeServicio);
                if (ViajeServicioToUpdate != null)
                {
                    ViajeServicioToUpdate.ViajeId = viajeServicio.ViajeId;
                    ViajeServicioToUpdate.ServicioId = viajeServicio.ServicioId;
                    _context.SaveChanges();

                }
                return ViajeServicioToUpdate;
            }
            catch (DbUpdateException ex)
            {
                throw new Conflict("Error en la modificación a la base de datos", ex);
            }
        }
    }
}
