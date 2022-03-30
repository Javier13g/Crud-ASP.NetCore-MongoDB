using MongoDB.Driver;
namespace crudSimple.Repositories
{
    public class mongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;

        public mongoDBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");

            db = client.GetDatabase("MusicalRepertoire");
        }
    }
}