using AdministradorContactosAPI.DTOs;
using AdministradorContactosAPI.Entidades;
using AdministradorContactosAPI.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministradorContactosAPI.Controllers
{
    [ApiController]
    [Route("api/contactos")]
    public class ContactoController: ControllerBase
    {
        private readonly IRepositorioContactos repositorioContactos;
        private readonly IRepositorioGrupo repositorioGrupo;

        public ContactoController(IRepositorioContactos repositorioContactos, IRepositorioGrupo repositorioGrupo)
        {
            this.repositorioContactos = repositorioContactos;
            this.repositorioGrupo = repositorioGrupo;
        }

        [HttpGet("{id:int}", Name = "ObtenerContacto")]
        public async Task<ActionResult<ContactoConGrupoDTO>> Get(int id)
        {
            //var entidad = await context.Contactos
            //    .Include(x => x.IdGrupoNavigation)
            //    .FirstOrDefaultAsync(x => x.Id == id);

            var entidad = await repositorioContactos.GetContactById(id);

            if (entidad is null)
            {
                return NotFound();    
            }

            var contactoGrupoDTO = new ContactoConGrupoDTO()
            {
                Id = entidad.Id,
                IdGrupo = entidad.IdGrupo,
                Nombre = entidad.Nombre,
                Email = entidad.Email,
                Telefono = entidad.Telefono,
            };

            return contactoGrupoDTO;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactoDTO>> Get()
        {
            var contactos = await repositorioContactos.GetContacts();

            return contactos;
        }

        [HttpGet("primero")]
        public async Task<ContactoDTO> GetPrimerContacto()
        {
            var contacto = await repositorioContactos.GetFirstContact();

            return contacto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactoCreacionDTO contactoCreacionDTO)
        {
            var contacto = new Contacto()
            {
                IdGrupo = contactoCreacionDTO.IdGrupo,
                Nombre = contactoCreacionDTO.Nombre,
                Email = contactoCreacionDTO.Email,
                Telefono = contactoCreacionDTO.Telefono
            };

            //var existeGrupo = await context.Grupos.AnyAsync(x => x.Id != contacto.IdGrupo);
            var existeGrupo = await repositorioGrupo.existGroup(contacto);

            if (!existeGrupo)
            {
                return NotFound($"El grupo de id {contacto.IdGrupo} no existe");
            }

            //context.Contactos.Add(contacto);
            //await context.SaveChangesAsync();

            var contactoDTO = await repositorioContactos.SaveContact(contacto); 
            //    new ContactoCreacionDTO()
            //{
            //    IdGrupo = contacto.IdGrupo,
            //    Nombre = contacto.Nombre,
            //    Email = contacto.Email,
            //    Telefono = contacto.Telefono
            //};

            return CreatedAtRoute("ObtenerContacto", new { id = contacto.Id }, contactoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ContactoCreacionDTO contactoDTO)
        {
            var contacto = new Contacto()
            {
                Id = id,
                IdGrupo = contactoDTO.IdGrupo,
                Nombre = contactoDTO.Nombre,
                Email = contactoDTO.Email,
                Telefono = contactoDTO.Telefono
            };

            //context.Contactos.Update(contacto);
            //await context.SaveChangesAsync();

            await repositorioContactos.UpdateContact(contacto);

            return NoContent();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var registrosBorrados = await repositorioContactos.Delete(id);
                //await context.Contactos.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (registrosBorrados == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("agrupar")]
        public async Task<List<GruposDTO>> Agrupar()
        {
            var resultado = await repositorioContactos.agruparAsync();

            return resultado;
        }


    }
}
