using Application.Exceptions;
using Application.Interfaces;
using Application.Requests;
using Application.responses;
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
        private readonly IServicioQuery _query;
        private readonly IServicioCommand _command;
        private readonly IViajeServicioService _viajeServicioService;

        public ServicioService(IServicioQuery query, IServicioCommand command, IViajeServicioService viajeServicioService)
        {
            _query = query;
            _command = command;
            _viajeServicioService = viajeServicioService;

        }


        public ServicioResponse CreateServicio(ServicioRequest servicioRequest)
        {
            try
            {
                Servicio servicio = new Servicio
                {
                    Nombre = servicioRequest.Nombre,
                    Descripción = servicioRequest.Descripcion,
                    Disponibilidad = servicioRequest.Disponibilidad,
                    Precio = servicioRequest.Precio,
                };
                if (VerifyHTTP409Insert(servicio))
                {
                    throw new Conflict("El servicio ya existe");
                }
                Servicio servicioIngresado = _command.InsertServicio(servicio);

                return new ServicioResponse
                {
                    Id = servicioIngresado.ServicioId,
                    Nombre = servicioIngresado.Nombre,
                    Descripcion = servicioIngresado.Descripción,
                    Disponibilidad = servicioIngresado.Disponibilidad,
                    Precio = servicioIngresado.Precio,
                };
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error en la implementación a la base de datos: " + ex.Message);
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del servicio en el registro");
            }


        }

        public ServicioResponse UpdateServicio(int IdServicio, ServicioRequest servicioRequest)
        {
            try
            {
                Servicio servicioToUpdate = new Servicio
                {
                    Nombre = servicioRequest.Nombre,
                    Descripción = servicioRequest.Descripcion,
                    Disponibilidad = servicioRequest.Disponibilidad,
                    Precio = servicioRequest.Precio,
                };
                servicioToUpdate.Nombre = char.ToUpper(servicioToUpdate.Nombre[0]) + servicioToUpdate.Nombre.Substring(1);
                if (VerifyHTTP404(IdServicio))
                {
                    throw new ExceptionNotFound("No existe un servicio con ese ID");
                }
                if (VerifyHTTP409Modify(servicioToUpdate))
                {
                    throw new Conflict("Existe otro servicio con el mismo nombre a modificar");
                }
                
                servicioToUpdate = _command.ModifyServicio(IdServicio, servicioToUpdate);
                return new ServicioResponse
                {
                    Id = servicioToUpdate.ServicioId,
                    Nombre = servicioToUpdate.Nombre,
                    Descripcion = servicioToUpdate.Descripción,
                    Disponibilidad = servicioToUpdate.Disponibilidad,
                    Precio = servicioToUpdate.Precio,
                };
            }
            catch (Conflict ex)
            {
                throw new Conflict("Error en la implementación a la base de datos: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error la busqueda en la base de datos: " + ex.Message);
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del servicio a modificar");
            }

        }

        public ServicioResponse DeleteServicio(int IdServicio)
        {
            try
            {
                if (VerifyHTTP404(IdServicio))
                {
                    throw new ExceptionNotFound("No existe un servicio con ese Id");
                }
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
            catch (ExceptionNotFound ex)
            {
                throw new Conflict("Error en la base de datos: " + ex.Message);
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Sintaxis incorrecta para el ID");
            }

        }

        //Debería mostrar la lista de los ViajeServicio en los que se encuentra?

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

        public GetServicioResponse GetServicioById(int IdServicio)
        {
            try
            {
                if (VerifyHTTP404(IdServicio))
                {
                    throw new ExceptionNotFound("No existe un servicio con ese Id");
                }
                List<GetViajeServicioResponse> ListaDeViajesConEseServicio = new List<GetViajeServicioResponse>();
                Servicio unServicio = _query.GetServicioById(IdServicio);
                foreach (ViajeServicio unViajeServicio in unServicio.ViajeServicios)
                {
                    GetViajeServicioResponse unViajeServicioResponse = new GetViajeServicioResponse
                    {
                        ViajeId = _viajeServicioService.GetViajeServicioById(unViajeServicio.ViajeId).ViajeId,
                        ViajeServicioId = _viajeServicioService.GetViajeServicioById(unViajeServicio.ViajeId).ViajeServicioId,
                    };
                    ListaDeViajesConEseServicio.Add(unViajeServicioResponse);
                }
                return new GetServicioResponse
                {
                    Id = unServicio.ServicioId,
                    Nombre = unServicio.Nombre,
                    Descripcion = unServicio.Descripción,
                    Disponibilidad = unServicio.Disponibilidad,
                    Precio = unServicio.Precio,
                    ServicioEnElViaje = ListaDeViajesConEseServicio,    
                };
            }
            catch (ExceptionSintaxError)
            {
                throw new ExceptionSintaxError("Error en la sintaxis del IDServicio a buscar");
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error en la búsqueda en la base de datos" + ex.Message);
            }
        }

        //Privates methods

        private bool VerifyHTTP409Insert(Servicio unServicio)
        {
            List<Servicio> listaServicios = _query.GetAllServicios();
            unServicio.Nombre = unServicio.Nombre.ToUpper();
            foreach (Servicio servicio in listaServicios)
            {
                servicio.Nombre = servicio.Nombre.ToUpper();
                if (servicio.Nombre.Equals(unServicio.Nombre))
                {
                    return true;
                }
            }
            return false;
        }
        
        private bool VerifyHTTP409Modify(Servicio unServicio)
        {
            List<Servicio> listaMercaderias = _query.GetAllServicios();
            unServicio.Nombre = unServicio.Nombre.ToUpper();
            foreach (Servicio servicio in listaMercaderias)
            {
                servicio.Nombre = servicio.Nombre.ToUpper();
                if (servicio.Nombre.Equals(unServicio.Nombre) && servicio.ServicioId != unServicio.ServicioId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool VerifyHTTP404(int IdServicio)
        {
            if ( _query.GetServicioById(IdServicio) == null)
            {
                return true;
            }
            return false;
        }
    }
}
