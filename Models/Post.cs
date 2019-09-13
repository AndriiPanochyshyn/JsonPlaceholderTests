using Newtonsoft.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist.Attributes;

namespace Models
{
    [Binding]
    public class Post : StepParameter<Post>
    {
        [JsonProperty("userId")]
        [TableAliases("User id")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        public override bool Equals(object obj)
        {
            return CheckEquality(this, obj);
        }

        public override string ToString()
        {
            return $"UserId - {UserId}; Id - {Id}; Title - {Title}; Body - {Body}";
        }
    }
}
