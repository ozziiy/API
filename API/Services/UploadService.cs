using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class UploadService
    {
        private readonly ArtistRepository _artistRepository;
        private readonly SongRepository _songRepository;

        public UploadService(SongRepository songRepository, ArtistRepository artistRepository)
        {
            _songRepository = songRepository;
            _artistRepository = artistRepository;
        }

        public async Task DeserializeUploadedArtists(string artists)
        {

            //using (Stream stream = artists.OpenReadStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string data = await reader.ReadToEndAsync();

            //    JObject artistsJSON = JObject.Parse(File.ReadAllText(data));

            //    List<Artist> artistsList = JsonConvert.DeserializeObject<List<Artist>>(artistsJSON.ToString());
            //}

            List<Artist> deserializedArtists = JsonConvert.DeserializeObject<List<Artist>>(artists);

            await _artistRepository.AddArtists(deserializedArtists);
        }

        public async Task DeserializeUploadedSongs(JsonElement songs)
        {
            var jsonString = songs.ToString();

            jsonString = jsonString.Replace("Artist", "ArtistId");

            JArray songsJsonArray = (JArray)JsonConvert.DeserializeObject(jsonString);

            for (int i = 0; i < songsJsonArray.Count; i++)
            {
                var songsJsonObject = songsJsonArray[i];
                var artistName = songsJsonObject["ArtistId"].ToString();

                var artist = await _artistRepository.GetArtistByName(artistName);

                if (artist != null)
                {
                    songsJsonObject["ArtistId"] = artist.Id;
                }
                else
                {
                    songsJsonArray.Remove(songsJsonObject);
                }
            }

            var jsonArrayString = songsJsonArray.ToString();

            List<Song> deserializedSongs = JsonConvert.DeserializeObject<List<Song>>(jsonArrayString);

            await _songRepository.AddSongs(deserializedSongs);
        }

    }
}
