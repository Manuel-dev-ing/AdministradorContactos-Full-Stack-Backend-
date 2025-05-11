using System.Diagnostics.Contracts;
using AdministradorContactosAPI.DTOs;
using AdministradorContactosAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AdministradorContactosAPI.Servicios
{
    public interface IRepositorioContactos
    {
        Task<List<GruposDTO>> agruparAsync();
        Task<int> Delete(int id);
        Task<Contacto> GetContactById(int id);
        Task<IEnumerable<ContactoDTO>> GetContacts();
        Task<ContactoDTO> GetFirstContact();
        Task<ContactoCreacionDTO> SaveContact(Contacto contacto);
        Task UpdateContact(Contacto contacto);
    }

    public class RepositorioContactos: IRepositorioContactos
    {
        private readonly ApplicationDbContext context;

        public RepositorioContactos(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Contacto> GetContactById(int id)
        {
            var entidad = await context.Contactos
                .Include(x => x.IdGrupoNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entidad;
        }

        public async Task<IEnumerable<ContactoDTO>> GetContacts()
        {
            var contactos = await context.Contactos
                .Include(x => x.IdGrupoNavigation)
                .Select(x => new ContactoDTO()
                {
                    Id = x.Id,
                    Grupo = x.IdGrupoNavigation.Nombre,
                    Nombre = x.Nombre,
                    Email = x.Email,
                    Telefono = x.Telefono
                }).ToListAsync();

            return contactos;
        }


        public async Task<ContactoDTO> GetFirstContact()
        {
            var contacto = await context.Contactos
                .Include(x => x.IdGrupoNavigation)
                .Select(x => new ContactoDTO()
                {
                    Id = x.Id,
                    Grupo = x.IdGrupoNavigation.Nombre,
                    Nombre = x.Nombre,
                    Email = x.Email,
                    Telefono = x.Telefono
                }).FirstAsync();

            return contacto;
        }

        public async Task<ContactoCreacionDTO> SaveContact(Contacto contacto) 
        {
            context.Contactos.Add(contacto);
            await context.SaveChangesAsync();

            var contactoDTO = new ContactoCreacionDTO()
            {
                IdGrupo = contacto.IdGrupo,
                Nombre = contacto.Nombre,
                Email = contacto.Email,
                Telefono = contacto.Telefono
            };

            return contactoDTO;
        }

        public async Task UpdateContact(Contacto contacto)
        {
            context.Contactos.Update(contacto);
            await context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var registrosBorrados = await context.Contactos.Where(x => x.Id == id).ExecuteDeleteAsync();
            
            return registrosBorrados;
        }

        public async Task<List<GruposDTO>> agruparAsync()
        {

            var resultado = await context.Contactos
                .Include(x => x.IdGrupoNavigation)
                .GroupBy(x => new { x.IdGrupoNavigation.Nombre, x.IdGrupoNavigation.Id } )
                .Select(a => new GruposDTO
                {
                    Id = a.Key.Id,
                    Grupo = a.Key.Nombre,
                    Cantidad = a.Count(),
                    Contactos = a.Select( x => new ContactoDTO 
                    { 
                        Id = x.Id, 
                        Grupo = x.IdGrupoNavigation.Nombre,
                        Nombre = x.Nombre,
                        Email = x.Email,
                        Telefono = x.Telefono
                    
                    }).ToList()

                }).ToListAsync();

            return resultado;
        }


    }
}
