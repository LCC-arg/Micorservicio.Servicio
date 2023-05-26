using Application.Exceptions;
using Application.Interfaces;
using Application.Requests;
using Application.responses;
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
        private readonly IViajeServicioQuery _query; IViajeServicioCommand _command; IServicioQuery _servQuery; IViajeApi _api;
        public ViajeServicioService(IViajeServicioQuery query, IViajeServicioCommand command, IServicioQuery servQuery, IViajeApi api)
        {
            _query = query;
            _command = command;
            _servQuery = servQuery;
            _api = api;
        }

        public ViajeServicioResponse CreateViajeServicio(ViajeServicioRequest viajeServicioRequest)
        {
            try
            {

                ViajeServicio unViajeServicio = new ViajeServicio
                {
                    ServicioId = viajeServicioRequest.ServicioId,
                    ViajeId = viajeServicioRequest.ViajeId,
                };
                var response = _api.GetViajeById(unViajeServicio.ViajeId);
                if (VerifyServicioID(unViajeServicio.ServicioId))
                {
                    throw new Conflict("El Servicio no existe");
                }
                if (VerifyHTTP409Insert(unViajeServicio))
                {
                    throw new Conflict("El Viaje Servicio ya existe");
                }
                ViajeServicio servicioIngresado = _command.InsertViajeServicio(unViajeServicio);
                
                return new ViajeServicioResponse
                {
                    ViajeServicioId = unViajeServicio.ViajeServicioId,
                    ViajeId = unViajeServicio.ViajeId,
                    ServicioId = unViajeServicio.ServicioId,
                };
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error en la implementación a la base de datos: " + ex.Message);
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del viaje servicio en el registro");
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionSintaxError("Error en la busqueda: "+ex.Message);
            }

        }

        public ViajeServicioResponse DeleteViajeServicio(int idViajeServicio)
        {
            try
            {
                if (VerifyHTTP404(idViajeServicio))
                {
                    throw new Conflict("No existe un servicio con ese Id");

                }
                ViajeServicio servicioEliminado = _command.DeleteViajeServicio(idViajeServicio);
                return new ViajeServicioResponse
                {
                    ViajeServicioId = servicioEliminado.ServicioId,
                    ViajeId = servicioEliminado.ViajeId,
                    ServicioId = servicioEliminado.ServicioId,
                };
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error en la base de datos: " + ex.Message);
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Sintaxis incorrecta para el ID");
            }

        }
        public ViajeServicioResponse UpdateViajeServicio(int idViajeServicio, ViajeServicioRequest viajeServicioRequest)
        {
            try
            {
                ViajeServicio viajeServicioToUpdate = new ViajeServicio
                {
                    ViajeServicioId = idViajeServicio,
                    ViajeId = viajeServicioRequest.ViajeId,
                    ServicioId = viajeServicioRequest.ServicioId,
                };
                if (VerifyHTTP404(viajeServicioToUpdate.ViajeServicioId))
                {
                    throw new ExceptionNotFound("No existe un viaje servicio con ese ID");
                }
                if (VerifyServicioID(viajeServicioToUpdate.ServicioId))
                {
                    throw new ExceptionNotFound("No existe un servicio con ese ID");
                }
                if (VerifyHTTP409Modify(viajeServicioToUpdate))
                {
                    throw new Conflict("Ya exite el servicio en ese viaje");
                }
                viajeServicioToUpdate = _command.ModifyViajeServicio(idViajeServicio, viajeServicioToUpdate);
                return new ViajeServicioResponse
                {
                    ViajeServicioId = viajeServicioToUpdate.ServicioId,
                    ViajeId = viajeServicioToUpdate.ViajeId,
                    ServicioId = viajeServicioToUpdate.ServicioId,
                };
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error en la implementación a la base de datos: " + ex.Message);
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Error en la sintaxis de la mercadería en el registro");
            }

        }

        public List<ViajeServicioResponse> GetAllViajesServicio()
        {
                List<ViajeServicio> listaViajeServicios = _query.GetAllViajeServicios();
                List<ViajeServicioResponse> listaViajeServiciosResponse = new List<ViajeServicioResponse>();
                foreach (ViajeServicio unViajeServicio in listaViajeServicios)
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
            try
            {
                if (VerifyHTTP404(idViajeServicio))
                {
                    throw new ExceptionNotFound("No existe un servicio con ese Id");
                }
                ViajeServicio unViajeServicio = _query.GetViajeServicioById(idViajeServicio);
                return new ViajeServicioResponse
                {
                    ViajeServicioId = unViajeServicio.ServicioId,
                    ViajeId = unViajeServicio.ViajeId,

                };
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del IDServicio a buscar");
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error en la búsqueda en la base de datos: " + ex.Message);
            }      
        }

        private bool VerifyHTTP409Insert(ViajeServicio unViajeServicio)
        {
            List<ViajeServicio> listaViajeServicios = _query.GetAllViajeServicios();
            foreach (ViajeServicio viajeServicio in listaViajeServicios)
            {
                
                if (viajeServicio.ViajeServicioId == unViajeServicio.ViajeServicioId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool VerifyHTTP409Modify(ViajeServicio unViajeServicio)
        {
            List<ViajeServicio> listaViajeServicios = _query.GetAllViajeServicios();
            foreach (ViajeServicio viajeServicio in listaViajeServicios)
            {
                if (unViajeServicio.ViajeServicioId != viajeServicio.ViajeServicioId && unViajeServicio.ViajeId == viajeServicio.ViajeId && unViajeServicio.ServicioId == viajeServicio.ServicioId)
                {
                    return true;
                }
            }
            return false;
        }
        private bool VerifyHTTP404(int IdViajeServicio)
        {
            if (_query.GetViajeServicioById(IdViajeServicio) == null)
            {
                return true;
            }
            return false;
        }
        private bool VerifyServicioID(int IdServicio)
        {
            if (_servQuery.GetServicioById(IdServicio) == null)
            {
                return true;
            }
            return false;
        }
    }
}
