﻿using Application.Exceptions;
using Application.Interfaces;
using Application.Requests;
using Application.responses;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeServicioController : ControllerBase
    {
        private readonly IViajeServicioService _service;
        public ViajeServicioController(IViajeServicioService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ViajeServicioResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult RegisterServicio(ViajeServicioRequest request)
        {
            try
            {
                var result = _service.CreateViajeServicio(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 409 };
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(ViajeServicioResponse), 200)]
        public IActionResult GetAllViajeServicios(int viajeId)
        {
            var result = _service.GetAllViajesServicio(viajeId);
            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ViajeServicioResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetViajeServicioById(int id)
        {
            try
            {
                var result = _service.GetViajeServicioById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(ViajeServicioResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult ModifyServicio(int Id, ViajeServicioRequest viajeServicio)
        {
            try
            {
                var result = _service.UpdateViajeServicio(Id, viajeServicio);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 409 };
            }
            catch (ExceptionNotFound ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 404 };
            }
        }


        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(ViajeServicioResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteServicio(int Id)
        {
            try
            {
                var result = _service.DeleteViajeServicio(Id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 400 };
            }
            catch (Conflict ex)
            {
                return new JsonResult(new BadRequest { Message = ex.Message }) { StatusCode = 409 };
            }
        }
    }
}
