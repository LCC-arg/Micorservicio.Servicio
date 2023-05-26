using Application.Exceptions;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Client
{
    public class ViajeApi: IViajeApi
    {
        private readonly HttpClient _httpClient;

        public ViajeApi()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7192/api/");
        }

        public dynamic GetViajeById(int viajeId)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Viaje/{viajeId}").Result;

            if (response.IsSuccessStatusCode)
            {
                dynamic viaje = response.Content.ReadAsAsync<dynamic>().Result;
                return viaje;
            }
            else
            {
                throw new ExceptionNotFound($"Error al obtener el Viaje. Código de respuesta: {response.StatusCode}");
            }
        }
    }
}
