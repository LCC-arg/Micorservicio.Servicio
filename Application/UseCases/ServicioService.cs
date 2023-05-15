using Application.Interfaces;
using Application.Requests;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioQuery _query; IServicioCommand _command;
        public ServicioService(IServicioQuery query, IServicioCommand command)
        {
            _query = query;
            _command = command;
        }


        public ServicioResponse CreateServicio(ServicioRequest servicioRequest)
        {
            Servicio servicio = new Servicio
            {
                Nombre = servicioRequest.Nombre,
                Descripción = servicioRequest.Descripcion,
                Disponibilidad = servicioRequest.Disponibilidad,
                Precio = servicioRequest.Precio,
            };
            Servicio servicioIngresado=_command.InsertServicio(servicio);
            return new ServicioResponse 
            {
                Id = servicioIngresado.ServicioId,
                Nombre = servicioIngresado.Nombre,
                Descripcion = servicioIngresado.Descripción,
                Disponibilidad = servicioIngresado.Disponibilidad,
                Precio = servicioIngresado.Precio,
            };
            
        }

        public ServicioResponse DeleteServicio(int IdServicio)
        {
            Servicio servicioEliminado = _command.DeleteServicio(IdServicio);
            return new ServicioResponse
            {
                Id = servicioEliminado.ServicioId,
                Nombre = servicioEliminado.Nombre,
                Descripcion = servicioEliminado.Descripción,
                Disponibilidad = servicioEliminado.Disponibilidad,
                Precio = servicioEliminado.Precio,
            };
        }

        public List<ServicioResponse> GetAllServicios()
        {
            List<Servicio> listaServicios = _query.GetAllServicios();
            List<ServicioResponse> listaServiciosResponse = new List<ServicioResponse>();
            foreach (Servicio unServicio in listaServicios)
            {
               ServicioResponse unServicioResponse = new ServicioResponse
                {
                    Id = unServicio.ServicioId,
                    Nombre = unServicio.Nombre,
                    Descripcion = unServicio.Descripción,
                    Disponibilidad = unServicio.Disponibilidad,
                    Precio = unServicio.Precio,
                };
                listaServiciosResponse.Add(unServicioResponse);
            }
            return listaServiciosResponse;
        }

        public ServicioResponse GetServicioById(int IdServicio)
        {
            Servicio unServicio = _query.GetServicioById(IdServicio);
            return new ServicioResponse
            {
                Id = unServicio.ServicioId,
                Nombre = unServicio.Nombre,
                Descripcion = unServicio.Descripción,
                Disponibilidad = unServicio.Disponibilidad,
                Precio = unServicio.Precio,
            };

        }

        public ServicioResponse UpdateServicio(int idServicio, ServicioRequest servicioRequest)
        {
            Servicio servicioToUpdate = new Servicio
            {
                Nombre = servicioRequest.Nombre,
                Descripción = servicioRequest.Descripcion,
                Disponibilidad = servicioRequest.Disponibilidad,
                Precio = servicioRequest.Precio,
            };
            servicioToUpdate = _command.ModifyServicio(idServicio, servicioToUpdate);
            return new ServicioResponse
            {
                Id = servicioToUpdate.ServicioId,
                Nombre = servicioToUpdate.Nombre,
                Descripcion = servicioToUpdate.Descripción,
                Disponibilidad = servicioToUpdate.Disponibilidad,
                Precio = servicioToUpdate.Precio,
            };
        }
    }
}
