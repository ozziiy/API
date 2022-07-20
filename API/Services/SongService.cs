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
    public class SongService
    {
        private readonly SongRepository _songRepository;


        public SongService(SongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<Song> GetSong(int id)
        {
            return await _songRepository.GetSong(id);
        }

        public async Task<IList<Song>> GetSongsByYearAndGenre()
        {
            return await _songRepository.GetSongsByYearAndGenre();
        }

        public async Task<Song> GetSongByName(string name)
        {
            return await _songRepository.GetSongByName(name);
        }

        public async Task AddSong(Song song)
        {
            await _songRepository.AddSong(song);
        }

        public async Task EditSong(Song song)
        {
            await _songRepository.EditSong(song);
        }

        public async Task RemoveSong(int id)
        {
            await _songRepository.DeleteSong(id);
        }
    }
}
