namespace Application.responses
{
    public class GetServicioResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Disponibilidad { get; set; }
        public int Precio { get; set; }
        public List<GetViajeServicioResponse> ServicioEnElViaje { get; set; }
    }
}
