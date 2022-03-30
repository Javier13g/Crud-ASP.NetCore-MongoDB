using System.Collections.Generic;
using crudSimple.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace crudSimple.Repositories
{
    public class AlbumCollection : IAlbumCollection
    {
        internal mongoDBRepository _repository = new mongoDBRepository();
        private IMongoCollection<Album> Collection;

        public AlbumCollection()
        {
            Collection = _repository.db.GetCollection<Album>("Albums");
        }

        public void InsertAlbum(Album album)
        {
            Collection.InsertOneAsync(album);
        }

        public void UpdateAlbum(Album album)
        {
            var filtrer = Builders<Album>
                 .Filter
                 .Eq(s => s.Id, album.Id);
            Collection.ReplaceOneAsync(filtrer, album);
        }

        public void DeleteAlbum(string id)
        {
            var filtrer = Builders<Album>.Filter.Eq(s => s.Id, new ObjectId(id));
            Collection.DeleteOneAsync(filtrer);
        }

        public List<Album> GetAllAlbums()
        {
            var query = Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }

        public Album GetAlbumById(string id)
        {
            var album = Collection.Find(
                new BsonDocument { { "_id", new ObjectId(id) } }
            ).FirstAsync().Result;

            return album;
        }
    }
}