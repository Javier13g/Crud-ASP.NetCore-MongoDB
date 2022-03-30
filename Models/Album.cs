using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace crudSimple.Models
{
    public class Album
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string AlbumImage { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public List<Song> Songs { get; set; }
    }
}