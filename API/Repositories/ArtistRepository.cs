using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class ArtistRepository
    {
        private readonly DatabaseContext _context;

        public ArtistRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Artist> GetArtist(int id)
        {
            return await _context.Artists.Where(a => a.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Artist> GetArtistByName(string name)
        {
            return await _context.Artists.Where(a => a.Name == name).SingleOrDefaultAsync();
        }

        public async Task AddArtists(IList<Artist> artists)
        {
            _context.Artists.AddRange(artists);       
            await _context.SaveChangesAsync();
        }

        public async Task AddArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task EditArtist(Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtist(int id)
        {
            Artist artist = await _context.Artists.Where(a => a.Id == id).SingleOrDefaultAsync();

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
        }
    }
}
