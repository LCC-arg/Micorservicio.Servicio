using Application.Exceptions;
using Application.Interfaces;
using Application.Requests;
using Application.responses;
using Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _service;
        public ServicioController(IServicioService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServicioResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult RegisterServicio(ServicioRequest request)
        {
            try
            {
                var result = _service.CreateServicio(request);
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
        [ProducesResponseType(typeof(ServicioResponse), 200)]
        public IActionResult GetAllServicios()
        {
            var result = _service.GetAllServicios();
            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServicioResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetServicioById(int id)
        {
            try
            {
                var result = _service.GetServicioById(id);
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
        [ProducesResponseType(typeof(ServicioResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult ModifyServicio(int Id, ServicioRequest servicio)
        {
            try
            {
                var result = _service.UpdateServicio(Id, servicio);
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
        [ProducesResponseType(typeof(ServicioResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteServicio(int Id)
        {
            try
            {
                var result = _service.DeleteServicio(Id);
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
