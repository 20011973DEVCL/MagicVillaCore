using System.Xml.Schema;
using AutoMapper;
using MagicVilla.Data;
using MagicVilla.Models;
using MagicVilla.Models.Dto;
using MagicVilla.Repositorio.IRepositorio;
using MagicVillaNetCore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVillaNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;

        // # Titulo  :   Agregar Interfaz Villa Repositorio 2
        // # Minuto  :   3:16:53
        // private readonly ApplicationDbContext _db;
        private readonly IVillaRepositorio _villaRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaController(ILogger<VillaController> logger, IVillaRepositorio villaRepo, IMapper mapper)
        {
            this._logger = logger;
            // this._db = db;
            this._villaRepo = villaRepo;
            this._mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
           try
           {
             _logger.LogInformation("Obtener todas la villas");
            // IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();
            IEnumerable<Villa> villaList = await _villaRepo.ObtenerTodos();

            _response.Resultado = _mapper.Map<IEnumerable<VillaDto>>(villaList);
            _response.statusCode = HttpStatusCode.OK;

            return Ok(_response);
           }
           catch (Exception ex)
           {
            _response.IsExitoso=false;
            _response.ErrorMessages=new List<string>() { ex.ToString() };
           }
           return _response;
        }

        [HttpGet("{id}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id==0)
                {
                    _logger.LogError("Error al traer la Villa con Id "+ id);
                    _response.IsExitoso = false;
                    _response.statusCode= HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                // var villa =await _db.Villas.FirstOrDefaultAsync(v=>v.Id==id);
                var villa = await _villaRepo.Obtener(v=>v.Id==id);
                if (villa==null)
                {
                    _response.IsExitoso = false;
                    _response.statusCode= HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                
                _response.Resultado = _mapper.Map<VillaDto>(villa);
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso=false;
                _response.ErrorMessages = new List<string>() {ex.ToString()};
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearVilla([FromBody] VillaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // var villa = await _db.Villas.FirstOrDefaultAsync(v=> v.Nombre.ToLower()== createDto.Nombre.ToLower());
                var villa = await _villaRepo.Obtener(v=> v.Nombre.ToLower()== createDto.Nombre.ToLower());
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

                // Estas Lineas se comentan ya que ahora se implemento el uso de interfaces.
                // await _db.Villas.AddAsync(modelo);
                // await _db.SaveChangesAsync();
                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;
                await _villaRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVilla", new { id = modelo.Id}, _response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso=false;
                _response.ErrorMessages = new List<string>() {ex.ToString()};
            }

            return _response;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> DeleteVilla(int id)
        {
            try
            {
                if (id==0)
                {
                    _response.IsExitoso=false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                // var villa= await _db.Villas.FirstOrDefaultAsync(v=>v.Id == id);
                var villa= await _villaRepo.Obtener(v=>v.Id == id);
                if (villa==null)
                {
                    _response.IsExitoso=false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                // Estas Lineas se comentan ya que ahora se implemento el uso de interfaces.
                // _db.Villas.Remove(villa);
                // await _db.SaveChangesAsync();
                await _villaRepo.Remover(villa);
                _response.statusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso=false;
                _response.ErrorMessages=new List<string>() {ex.ToString()};
            }
            return BadRequest(_response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> UpdateVilla([FromBody] VillaUpdateDto updateDto, int id)
        {
            try
            {
                if (updateDto == null || id!= updateDto.Id)
                {
                    _response.IsExitoso=false;
                    _response.statusCode =HttpStatusCode.BadRequest;
                    return BadRequest(_response);
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

                // Estas Lineas se comentan ya que ahora se implemento el uso de interfaces.
                // _db.Update(modelo);
                // await _db.SaveChangesAsync();

                await _villaRepo.Actualizar(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() {ex.ToString()};
            }

            return BadRequest(_response);
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