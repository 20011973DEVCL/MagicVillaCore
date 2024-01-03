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
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        private readonly IVillaRepositorio _villaRepo;
        private readonly INumeroVillaRepositorio _numeroRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public NumeroVillaController(ILogger<NumeroVillaController> logger, IVillaRepositorio villaRepo,
            INumeroVillaRepositorio numeroRepo, IMapper mapper)
        {
            this._logger = logger;
            this._villaRepo = villaRepo;
            this._numeroRepo = numeroRepo;
            this._mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetNumerosVillas()
        {
           try
           {
             _logger.LogInformation("Obtener Numeros de Villas");
            IEnumerable<NumeroVilla> numeroVillaList = await _numeroRepo.ObtenerTodos();

            _response.Resultado = _mapper.Map<IEnumerable<NumeroVillaDto>>(numeroVillaList);
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

        [HttpGet("{id}", Name = "GetNumeroVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetNumeroVilla(int id)
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
                var numeroVilla = await _numeroRepo.Obtener(v=>v.VillaNo==id);
                if (numeroVilla==null)
                {
                    _response.IsExitoso = false;
                    _response.statusCode= HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                
                _response.Resultado = _mapper.Map<NumeroVillaDto>(numeroVilla);
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
        public async Task<ActionResult<APIResponse>> CrearNumeroVilla([FromBody] NumeroVillaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var numeroVilla = await _numeroRepo.Obtener(v=> v.VillaNo== createDto.VillaNo);
                if (numeroVilla!=null)
                {
                    ModelState.AddModelError("ValidacionDeNumeros", "El numero de villa ingresado ya Existe");
                    return BadRequest(ModelState);
                }
                var villa = await _villaRepo.Obtener(v=>v.Id == createDto.VillaId);
                if (villa ==null)
                {
                    ModelState.AddModelError("ClaveForanea", "El ID de la villa no Existe");
                    return BadRequest(ModelState);
                }

                if (createDto==null)
                {
                    return BadRequest(createDto);
                }

                NumeroVilla modelo = _mapper.Map<NumeroVilla>(createDto);

                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;
                await _numeroRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetNumeroVilla", new { id = modelo.VillaNo}, _response);
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
        public async Task<IActionResult> DeleteNumeroVilla(int id)
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
                var numeroVilla= await _numeroRepo.Obtener(v=>v.VillaNo == id);
                if (numeroVilla==null)
                {
                    _response.IsExitoso=false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _numeroRepo.Remover(numeroVilla);
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
        public async Task<IActionResult> UpdateNumeroVilla([FromBody] NumeroVillaUpdateDto updateDto, int id)
        {
            try
            {
                if (updateDto == null || id!= updateDto.VillaNo)
                {
                    _response.IsExitoso=false;
                    _response.statusCode =HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                NumeroVilla modelo = _mapper.Map<NumeroVilla>(updateDto);

                await _numeroRepo.Actualizar(modelo);
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
    }
}