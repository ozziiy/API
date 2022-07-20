using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class SongRepository
    {
        private readonly DatabaseContext _context;

        public SongRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Song> GetSong(int id)
        {
            return await _context.Songs.Where(a => a.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Song> GetSongByName(string name)
        {
            return await _context.Songs.Where(a => a.Name == name).SingleOrDefaultAsync();
        }

        public async Task<IList<Song>> GetSongsByYearAndGenre()
        {
            return await _context.Songs.Where(a => a.Genre == "Metal" && a.Year < 2016).ToListAsync();
        }

        public async Task AddSongs(IList<Song> songs)
        {
            _context.Songs.AddRange(songs);       
            await _context.SaveChangesAsync();
        }

        public async Task AddSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task EditSong(Song song)
        {
            _context.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSong(int id)
        {
            Song song = await _context.Songs.Where(s => s.Id == id).SingleOrDefaultAsync();

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
}
