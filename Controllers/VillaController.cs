using System.Xml.Schema;
using AutoMapper;
using MagicVilla.Data;
using MagicVilla.Models.Dto;
using MagicVillaNetCore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db, IMapper mapper)
        {
            this._logger = logger;
            this._db = db;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {
            _logger.LogInformation("Obtener todas la villas");
            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<VillaDto>>(villaList));
        }

        [HttpGet("{id}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
        {
            if (id==0)
            {
                _logger.LogError("Error al traer la Villa con Id "+ id);
                return BadRequest();
            }

            var villa =await _db.Villas.FirstOrDefaultAsync(v=>v.Id==id);
            if (villa==null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<IEnumerable<VillaDto>>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> CrearVilla([FromBody] VillaCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(v=> v.Nombre.ToLower()== createDto.Nombre.ToLower());
            if (villa!=null)
            {
                ModelState.AddModelError("ValidacionDeNombres", "El nombre ingresado ya Existe");
                return BadRequest(ModelState);
            }

            if (createDto==null)
            {
                return BadRequest(createDto);
            }

            Villa modelo = _mapper.Map<Villa>(createDto);

            // La linea de arriba reemplaza a todos este bloque ya que utiliza AutoMapping
            // Esto se utiliza en el caso de que los modelos tengan demasiados campos
            // y no extar escribiendolos 1 a 1
            // Villa modelo = new()
            // {
            //     Nombre=createDto.Nombre,
            //     Detalle=createDto.Detalle,
            //     Tarifa = createDto.Tarifa,
            //     Ocupantes = createDto.Ocupantes,
            //     MetrosCuadrados = createDto.MetrosCuadrados,
            //     ImagenUrl = createDto.ImagenUrl,
            //     Amenidad = createDto.Amenidad,
            //     FechaCreacion = DateTime.Now
            // };
            await _db.Villas.AddAsync(modelo);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = modelo.Id}, modelo);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }

            var villa= await _db.Villas.FirstOrDefaultAsync(v=>v.Id == id);
            if (villa==null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> UpdateVilla([FromBody] VillaUpdateDto updateDto, int id)
        {
            if (updateDto == null || id!= updateDto.Id)
            {
                return BadRequest();
            }

            Villa modelo = _mapper.Map<Villa>(updateDto);

            // Idem a lo Explicado en el CrearVilla
            // Villa modelo = new()
            // {
            //     Id=villaDto.Id,
            //     Nombre=villaDto.Nombre,
            //     Detalle=villaDto.Detalle,
            //     Tarifa = villaDto.Tarifa,
            //     Ocupantes = villaDto.Ocupantes,
            //     MetrosCuadrados = villaDto.MetrosCuadrados,
            //     ImagenUrl = villaDto.ImagenUrl,
            //     Amenidad = villaDto.Amenidad,
            //     FechaActualizacion = DateTime.Now
            // };
            _db.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // [HttpPatch("{id}")]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)] 
        // public async Task<IActionResult> UpdatePartialVilla(JsonPatchDocument<VillaUpdateDto> patchDto, int id)
        // {
        //     if (patchDto == null || id == 0)
        //     {
        //         return BadRequest();
        //     }

        //     var villa= _db.Villas.AsNoTracking().FirstOrDefault(v=>v.Id == id);

        //     VillaDto villaDto = _mapper.Map<VillaDto>(villa);
        //     if (villa==null){
        //         return BadRequest();
        //     }

        //     patchDto.ApplyTo(villaDto, ModelState);
            
        //     if(!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     Villa modelo = _mapper.Map<Villa>(villaDto);

        //     _db.Update(modelo);
        //     await _db.SaveChangesAsync();

        //     return NoContent();
        // } 
    }
}