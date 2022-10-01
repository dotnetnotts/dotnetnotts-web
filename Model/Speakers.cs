using System.Text.Json.Serialization;

namespace dotnetnotts.Model
{
    public class Speakers
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }

        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        [JsonPropertyName("tagLine")]
        public string? TagLine { get; set; }

        [JsonPropertyName("profilePicture")]
        public Uri? ProfilePicture { get; set; }

        [JsonPropertyName("sessions")]
        public Session[]? Sessions { get; set; }

        [JsonPropertyName("isTopSpeaker")]
        public bool IsTopSpeaker { get; set; }

        [JsonPropertyName("links")]
        public object[]? Links { get; set; }

        [JsonPropertyName("questionAnswers")]
        public object[]? QuestionAnswers { get; set; }

        [JsonPropertyName("categories")]
        public object[]? Categories { get; set; }
    }

    public class Session
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
