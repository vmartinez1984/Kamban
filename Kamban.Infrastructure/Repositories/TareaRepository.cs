using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Kamban.Infrastructure.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly IMongoCollection<Tarea> _collection;

        public TareaRepository(IConfiguration configurations)
        {
            var mongoClient = new MongoClient(configurations.GetConnectionString("mongoDb"));
            var mongoDatabase = mongoClient.GetDatabase(configurations.GetConnectionString("mongoDbNombre"));
            _collection = mongoDatabase.GetCollection<Tarea>("Tareas");
        }

        public async Task<string> Agregar(Tarea item)
        {
            if (item.Id == 0)
                item.Id = await ObtenerId();
            await _collection.InsertOneAsync(item);

            return item.Id.ToString();
        }

        private async Task<int> ObtenerId()
        {
            var item = await
            _collection
            .Find(new BsonDocument()) // Puedes agregar filtros si es necesario
            .SortByDescending(r => r.Id) // Ordenar por fecha de forma descendente
            .FirstOrDefaultAsync();
            ;
            if (item == null)
                return 1;

            return item.Id + 1;
        }

        public async Task ActualizarAsync(Tarea ahorro)
        {
            await _collection.ReplaceOneAsync(a => a._id == ahorro._id, ahorro);
        }

        public async Task<Tarea> ObtenerPorIdAsync(string idGuid)
        {
            Tarea ahorro;
            int id;

            if (int.TryParse(idGuid, out id))
                ahorro = (await _collection.FindAsync<Tarea>(x => x.Id == id)).FirstOrDefault();
            else
                ahorro = (await _collection.FindAsync<Tarea>(x => x.EncodedKey == idGuid)).FirstOrDefault();

            return ahorro;
        }

        public async Task<List<Tarea>> ObtenerTodosAsync() =>
            //(await _collection.FindAsync(x => x.Estado != "Inactivo")).ToList();
            (await _collection.FindAsync(_ => true)).ToList();

        public async Task<List<Tarea>> ObtenerTodosAsync(string estado = null)
        {
            if (string.IsNullOrEmpty(estado))
                return (await _collection.FindAsync(_ => true)).ToList();
            else
                return (await _collection.FindAsync(x => x.Estado == estado)).ToList();
        }
    }
}
