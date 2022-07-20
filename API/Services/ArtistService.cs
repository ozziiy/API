using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class ArtistService
    {
        private readonly ArtistRepository _artistRepository;

        public ArtistService(ArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<Artist> GetArtist(int id)
        {
            return await _artistRepository.GetArtist(id);
        }

        public async Task AddArtist(Artist artist)
        {
            await _artistRepository.AddArtist(artist);
        }

        public async Task EditArtist(Artist artist)
        {
            await _artistRepository.EditArtist(artist);
        }

        public async Task RemoveArtist(int id)
        {
            await _artistRepository.DeleteArtist(id);
        }
    }
}
