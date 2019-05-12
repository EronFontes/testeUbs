using Newtonsoft.Json;

namespace Model
{
    public class Person
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Company { get; set; }
        public string Hash { get; set; }
    }
}
