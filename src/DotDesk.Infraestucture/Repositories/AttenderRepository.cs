using DotDesk.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection;

namespace DotDesk.Infraestucture.Repositories
{
    public class AttenderRepository : IAttenderRepository
    {
        private readonly IMongoCollection<Attender> _attenders;

        public AttenderRepository(IMongoDatabase database)
        {
            _attenders = database.GetCollection<Attender>("Attenders");
        }

        public async Task<Attender> Create(Attender newAttender)
        {
            await _attenders.InsertOneAsync(newAttender);
            return newAttender;
        }

        public async Task<Attender> Get(Attender attenderFilter)
        {
            FilterDefinitionBuilder<Attender> filterBuilder = Builders<Attender>.Filter;
            List<FilterDefinition<Attender>> filters = new();

            PropertyInfo[] properties = typeof(Attender).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object? value = prop.GetValue(attenderFilter);
                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                {
                    filters.Add(filterBuilder.Eq(prop.Name, value));
                }
            }

            FilterDefinition<Attender> filter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

            return await _attenders.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Attender> Get(string id)
        {
            FilterDefinitionBuilder<Attender> filterBuilder = Builders<Attender>.Filter;
            List<FilterDefinition<Attender>> filters = new();
            filters.Add(filterBuilder.Eq("_id", ObjectId.Parse(id)));

            FilterDefinition<Attender> filter = filterBuilder.And(filters);

            return await _attenders.Find(filter).FirstOrDefaultAsync();
        }

    }
}
