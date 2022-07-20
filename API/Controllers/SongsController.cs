
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly SongService _songService;

        public SongsController(SongService songService)
        {
            _songService = songService;
        }


        [HttpGet("{id}")]
        public async Task<Song> GetSong([FromRoute] int id)
        {
            try
            {
                return await _songService.GetSong(id);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [HttpGet]
        [Route("specificSongs")]
        public async Task<IList<Song>> GetSongsByYearAndGenre()
        {
            try
            {
                return await _songService.GetSongsByYearAndGenre();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostSong([FromBody] Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSong = await _songService.GetSongByName(song.Name);

            if (existingSong == null)
            {
                try
                {
                    await _songService.AddSong(song);

                    return Ok();
                }
                catch (Exception e)
                {
                    throw (e);
                }

            }
            else
            {
                return BadRequest("The song already exists in the database");
            }
        }


        [HttpPut]
        public async Task<IActionResult> EditSong([FromBody] Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _songService.EditSong(song);
                return Ok();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute] int id)
        {
            Song song = await _songService.GetSong(id);

            if (song == null)
            {
                return BadRequest("The given song id doesn't exist in the database.");
            }

            try
            {
                await _songService.RemoveSong(id);

                return Ok();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
