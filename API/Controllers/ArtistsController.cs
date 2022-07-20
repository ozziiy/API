using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistService _artistService;

        public ArtistsController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        //[HttpGet]
        //public async Task<IList<Artist>> GetArtists()
        //{
        //    try
        //    {
        //        return await _context.Artists.Include(c => c.song).ToListAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw (e);
        //    }

        //}

        [HttpGet("{id}")]
        public async Task<Artist> GetArtist([FromRoute] int id)
        {
            try
            {
                return await _artistService.GetArtist(id);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }


        [HttpPost]
        public async Task<IActionResult> PostArtist([FromBody] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _artistService.AddArtist(artist);

                return Ok();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }


        [HttpPut]
        public async Task<IActionResult> EditArtist([FromBody] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _artistService.EditArtist(artist);
                return Ok();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist([FromRoute] int id)
        {
            Artist artist = await _artistService.GetArtist(id);

            if (artist == null)
            {
                return BadRequest("The given artist id doesn't exist in the database.");
            }

            try
            {
                await _artistService.RemoveArtist(id);

                return Ok();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
