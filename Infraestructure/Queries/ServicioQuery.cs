﻿using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            catch (DbUpdateException)
            {
                throw new ExceptionNotFound("No se encontraron los servicios solicitado");
            }
        }

        public Servicio GetServicioById(int idServicio)
        {
            try
            {
                Servicio unServicio = _context.Servicio
                    //.Include(s => s.ViajeServicios)
                    .SingleOrDefault(x => x.ServicioId == idServicio);
                return unServicio;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionNotFound("No se encontró el servicio solicitado");
            }
        }
    }
}
