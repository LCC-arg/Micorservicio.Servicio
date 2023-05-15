using Application.Interfaces;
using Application.Requests;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ViajeServicioService : IViajeServicioService
    {
        private readonly IViajeServicioQuery _query; IViajeServicioCommand _command;
        public ViajeServicioService(IViajeServicioQuery query, IViajeServicioCommand command)
        {
            _query = query;
            _command = command;
        }

        public ViajeServicioResponse CreateViajeServicio(ViajeServicioRequest viajeServicioRequest)
        {
            ViajeServicio unViajeServicio = new ViajeServicio
            {
                ServicioId = viajeServicioRequest.ServicioId,
                ViajeId = viajeServicioRequest.ViajeId,
            };
            ViajeServicio servicioIngresado = _command.InsertViajeServicio(unViajeServicio);

            return new ViajeServicioResponse
            {
                ViajeServicioId = unViajeServicio.ServicioId,
                ViajeId = unViajeServicio.ViajeId,
                ServicioId = unViajeServicio.ServicioId,
            };
        }

        public ViajeServicioResponse DeleteViajeServicio(int idViajeServicio)
        {
            ViajeServicio servicioEliminado = _command.DeleteViajeServicio(idViajeServicio);
            return new ViajeServicioResponse
            {
                ViajeServicioId = servicioEliminado.ServicioId,
                ViajeId = servicioEliminado.ViajeId,
                ServicioId = servicioEliminado.ServicioId,
            };
        }
        public ViajeServicioResponse UpdateViajeServicio(int idViajeServicio, ViajeServicioRequest viajeServicioRequest)
        {
            ViajeServicio viajeServicioToUpdate = new ViajeServicio
            {
                ViajeServicioId = viajeServicioRequest.ServicioId,
                ViajeId = viajeServicioRequest.ViajeId,
                ServicioId = viajeServicioRequest.ServicioId,
            };
            viajeServicioToUpdate = _command.ModifyViajeServicio(idViajeServicio, viajeServicioToUpdate);
            return new ViajeServicioResponse
            {
                ViajeServicioId = viajeServicioToUpdate.ServicioId,
                ViajeId = viajeServicioToUpdate.ViajeId,
                ServicioId = viajeServicioToUpdate.ServicioId,
            };
        }

        public List<ViajeServicioResponse> GetAllViajesServicio()
        {
            List<ViajeServicio> listaServicios = _query.GetAllViajeServicios();
            List<ViajeServicioResponse> listaViajeServiciosResponse = new List<ViajeServicioResponse>();
            foreach (ViajeServicio unViajeServicio in listaServicios)
            {
                ViajeServicioResponse unViajeServicioResponse = new ViajeServicioResponse
                {
                    ViajeServicioId = unViajeServicio.ServicioId,
                    ViajeId = unViajeServicio.ViajeId,
                    ServicioId = unViajeServicio.ServicioId,
                };
                listaViajeServiciosResponse.Add(unViajeServicioResponse);
            }
            return listaViajeServiciosResponse;
        }

        public ViajeServicioResponse GetViajeServicioById(int idViajeServicio)
        {
            ViajeServicio unViajeServicio = _query.GetViajeServicioById(idViajeServicio);
            return new ViajeServicioResponse
            {
                ViajeServicioId = unViajeServicio.ServicioId,
                ViajeId = unViajeServicio.ViajeId,
                ServicioId = unViajeServicio.ServicioId,
            };
        }

        
    }
}
