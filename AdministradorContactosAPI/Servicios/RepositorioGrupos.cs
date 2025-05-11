using System.Text.RegularExpressions;
using AdministradorContactosAPI.DTOs;
using AdministradorContactosAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AdministradorContactosAPI.Servicios
{
    public interface IRepositorioGrupo
    {
        Task<int> DeleteGroup(int id);
        Task<bool> existGroup(Contacto contacto);
        Task<GruposConContactosDTO> GetGrupById(int id);
        Task<IEnumerable<GrupoDTO>> GetGrups();
        Task<GrupoCreacionDTO> SaveGroup(Grupo grupo);
        Task UpdateGroup(Grupo grupo);
    }

    public class RepositorioGrupos:IRepositorioGrupo
    {
        private readonly ApplicationDbContext context;

        public RepositorioGrupos(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<bool> existGroup(Contacto contacto)
        {

            var existeGrupo = await context.Grupos.AnyAsync(x => x.Id != contacto.IdGrupo);
            return existeGrupo;

        }

        public async Task<IEnumerable<GrupoDTO>> GetGrups()
        {
            var grupo = await context.Grupos
             .Select(x => new GrupoDTO()
             {
                 Id = x.Id,
                 Nombre = x.Nombre
             })
             .ToListAsync();

            return grupo;
        }

        public async Task<GruposConContactosDTO> GetGrupById(int id)
        {
            var entidad = await context.Grupos
                .Include(x => x.Contactos)
                .Select(x => new GruposConContactosDTO()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Contactos = x.Contactos.Select(c => new ContactDTO()
                    {
                        Id = c.Id,
                        IdGrupo = (int)c.IdGrupo,
                        Nombre = c.Nombre,
                        Email = c.Email,
                        Telefono = c.Telefono

                    }).ToList()

                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return entidad;
        }

        public async Task<GrupoCreacionDTO> SaveGroup(Grupo grupo)
        {

            context.Grupos.Add(grupo);
            await context.SaveChangesAsync();

            var grupocreacionDTO = new GrupoCreacionDTO()
            {
                Nombre = grupo.Nombre
            };

            return grupocreacionDTO;

        }

        public async Task UpdateGroup(Grupo grupo)
        {
            context.Grupos.Update(grupo);
            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteGroup(int id)
        {
            var entidad = await context.Grupos.Where(x => x.Id == id).ExecuteDeleteAsync();

            return entidad;
        }

    }


}
