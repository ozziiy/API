using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

        public int ArtistId { get; set; }

        public string Shortname { get; set; }

        public int Bpm { get; set; }

        public int Duration { get; set; }

        public string Genre { get; set; }

        public string SpotifyId { get; set; }

        public string Album { get; set; }
    }
}
