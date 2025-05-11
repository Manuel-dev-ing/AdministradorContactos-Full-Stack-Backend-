using AdministradorContactosAPI.DTOs;
using AdministradorContactosAPI.Entidades;
using AdministradorContactosAPI.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdministradorContactosAPI.Controllers
{
    [ApiController]
    [Route("api/grupos")]
    public class GrupoController : ControllerBase
    {
        private readonly IRepositorioGrupo repositorioGrupo;

        public GrupoController(IRepositorioGrupo repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }

        [HttpGet]
        public async Task<IEnumerable<GrupoDTO>> Get()
        {

            var grupo = await repositorioGrupo.GetGrups();
                //await context.Grupos
                //.Select(x => new GrupoDTO()
                //{
                //    Id = x.Id,
                //    Nombre = x.Nombre
                //})
                //.ToListAsync();


            return grupo;
        }

        [HttpGet("{id:int}", Name = "ObtenerGrupo")]
        public async Task<ActionResult<GruposConContactosDTO>> Get(int id)
        {
            var entidad = await repositorioGrupo.GetGrupById(id);
                //context.Grupos
                //.Include(x => x.Contactos)
                //.FirstOrDefaultAsync(x => x.Id == id);

            if (entidad is null)
            {
                return NotFound();
            }

            //var grupoConContacto = new GruposConContactosDTO()
            //{
            //    Id = entidad.Id,
            //    Nombre = entidad.Nombre,
            //    Contactos = entidad.Contactos
            //};

            return entidad;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GrupoCreacionDTO grupoDTO)
        {
            var grupo = new Grupo()
            {
                Nombre = grupoDTO.Nombre
            };

            //context.Grupos.Add(grupo);
            //await context.SaveChangesAsync();

            var grupocreacionDTO = await repositorioGrupo.SaveGroup(grupo);
            //    new GrupoCreacionDTO()
            //{
            //    Nombre = grupo.Nombre
            //};

            return CreatedAtRoute("ObtenerGrupo", new { id = grupo.Id }, grupocreacionDTO);

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GrupoCreacionDTO grupoCreacionDTO)
        {
            var grupo = new Grupo()
            {
                Id = id,
                Nombre = grupoCreacionDTO.Nombre
            };

            //context.Grupos.Update(grupo);
            //await context.SaveChangesAsync();
            await repositorioGrupo.UpdateGroup(grupo);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entidad = await repositorioGrupo.DeleteGroup(id); 
                //await context.Grupos.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (entidad == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
