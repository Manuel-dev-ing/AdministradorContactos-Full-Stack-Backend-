namespace AdministradorContactosAPI.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }

        public string Nombre { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }
    }
}
