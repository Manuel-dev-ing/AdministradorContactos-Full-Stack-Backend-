namespace AdministradorContactosAPI.DTOs
{
    public class GruposDTO
    {
        public int Id { get; set; }
        public string Grupo { get; set; }
        public int Cantidad { get; set; }
        public List<ContactoDTO> Contactos { get; set; }


    }
}
