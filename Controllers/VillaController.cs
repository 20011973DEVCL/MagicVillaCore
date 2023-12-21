using MagicVilla.Data;
using MagicVilla.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.VillaList);
        }

        [HttpGet("{id}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }

            var villa = VillaStore.VillaList.FirstOrDefault(v=>v.Id==id);
            if (villa==null)
            {
                return NotFound();
            }
            
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var villa = VillaStore.VillaList.FirstOrDefault(v=> v.Nombre.ToLower()== villaDto.Nombre.ToLower());
            if (villa!=null)
            {
                ModelState.AddModelError("ValidacionDeNombres", "El nombre ingresado ya Existe");
                return BadRequest(ModelState);
            }

            if (villaDto==null)
            {
                return BadRequest(villaDto);
            }

            if (villaDto.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDto.Id = VillaStore.VillaList.OrderByDescending(v => v.Id).FirstOrDefault().Id +1;
            VillaStore.VillaList.Add(villaDto);
            return CreatedAtRoute("GetVilla", new { id = villaDto.Id}, villaDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public IActionResult DeleteVilla(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }

            var villa= VillaStore.VillaList.FirstOrDefault(v=>v.Id == id);
            if (villa==null)
            {
                return NotFound();
            }
            VillaStore.VillaList.Remove(villa);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public IActionResult UpdateVilla([FromBody] VillaDto villaDto, int id)
        {
            if (villaDto == null || id!= villaDto.Id)
            {
                return BadRequest();
            }

            var villa= VillaStore.VillaList.FirstOrDefault(v=>v.Id == id);
            villa.Nombre = villaDto.Nombre;
            villa.Ocupantes = villaDto.Ocupantes;
            villa.MetrosCuadrados = villaDto.MetrosCuadrados;
            
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public IActionResult UpdatePartialVilla(JsonPatchDocument<VillaDto> patchDto, int id)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            var villa= VillaStore.VillaList.FirstOrDefault(v=>v.Id == id);
            patchDto.ApplyTo(villa, ModelState);
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        } 
    }
}