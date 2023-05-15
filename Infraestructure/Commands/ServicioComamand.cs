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
    public class ServicioCommand : IServicioCommand
    {
        private readonly ServiciosContext _context;

        public ServicioCommand(ServiciosContext context)
        {
            _context = context;
        }

        public Servicio DeleteServicio(int idServicio)
        {
            try
            {
                Servicio unServicio = _context.Servicio.SingleOrDefault(x => x.ServicioId == idServicio);
                _context.Remove(unServicio);
                _context.SaveChanges();
                return unServicio;
            }
            catch (DbUpdateException ex)
            {
                throw new Conflict("Error en borrar el servicio de la base de datos", ex);
            }
        }

        public Servicio InsertServicio(Servicio unServicio)
        {

            try
            {
                _context.Add(unServicio);
                _context.SaveChanges();
                return unServicio;
            }
            catch(DbUpdateException ex)
            {

                throw new Conflict("Error en la inserción a la base de datos", ex);
            }
        }

        public Servicio ModifyServicio(int idServicio, Servicio servicio)
        {
            try
            {
                var servicioToUpdate = _context.Servicio.FirstOrDefault(s => s.ServicioId == idServicio);
                if (servicioToUpdate != null)
                {
                    servicioToUpdate.Nombre = servicio.Nombre;
                    servicioToUpdate.Descripción = servicio.Descripción;
                    servicioToUpdate.Disponibilidad = servicio.Disponibilidad;
                    servicioToUpdate.Precio = servicio.Precio;
                    _context.SaveChanges();

                }
                return servicioToUpdate;
            }
            catch (DbUpdateException ex)
            {
                throw new Conflict("Error en la modificación a la base de datos", ex);
            }
        }
    }
}