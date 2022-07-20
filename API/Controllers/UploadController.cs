using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {

        private readonly UploadService _uploadService;

        public UploadController(UploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost]
        [Route("artists")]
        public async Task<IActionResult> UploadArtists([FromForm] string artists)
        {
            try
            {
                await _uploadService.DeserializeUploadedArtists(artists);
                return Ok();
            }
             catch (Exception e)
            {
                throw (e);
            }
        }

        [HttpPost]
        [Route("songs")]
        public async Task<IActionResult> UploadSongs([FromBody] JsonElement songs)
        {
            try
            {
                await _uploadService.DeserializeUploadedSongs(songs);
                return Ok();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
