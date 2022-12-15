﻿using MagicVillaWebAPI.Data;
using MagicVillaWebAPI.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaWebAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase

    {
        private const int V = 200;

        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]

        //[ProducesResponseTypeAttribute(StatusCodes.Status200OK, Type = typeof(VillaDto))]
        //[ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        //[ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]

        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(VillaStore.villaList.FirstOrDefault(u => u.Id == id));
        }

        [HttpPost]
        [ProducesResponseTypeAttribute(StatusCodes.Status201Created)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        [ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {
            // if you don't want to include ApiController in above you need to definde own validation like this
            //if (ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            // Custom validation to test wheather the name exists or not
            if (VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villaDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa Already Exists!");
                return BadRequest(ModelState);
            }
            if (villaDto == null)
            {
                return BadRequest(villaDto);
            }

            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDto.Id = VillaStore.villaList.OrderByDescending(u => u.Id)
                .FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDto);
            return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]

        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            VillaStore.villaList.Remove(villa);
            return NoContent();
        }

    }
}
