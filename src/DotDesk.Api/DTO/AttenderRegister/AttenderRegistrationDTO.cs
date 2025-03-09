using DotDesk.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotDesk.Api.DTO.AttenderRegister
{
    public sealed class AttenderRegistrationDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static AttenderRegistrationDTO CreateDtoFrom(Attender attender)
            => new AttenderRegistrationDTO()
            {
                Id = attender.Id,
                Name = attender.Name,
                Email = attender.Email
            };

        public Attender ExtractAttender()
            => new Attender(name: Name, email: Email); 
    }
}
