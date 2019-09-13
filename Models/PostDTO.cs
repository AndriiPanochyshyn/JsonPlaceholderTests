using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace Models
{
    [Binding]
    public class PostDTO : StepParameter<PostDTO>
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
