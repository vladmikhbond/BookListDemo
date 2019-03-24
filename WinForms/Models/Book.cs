using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WinForms.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; }
        public string Title { set; get; }
        public string Authors { set; get; }
    }
}
