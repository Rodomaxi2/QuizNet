using System.Text.Json.Serialization;

namespace poll_api.Models;

public class Question
{
    public Guid Id {get; set;}
    public string QuestionText {get; set;}

    // Navigation Properties
    // [JsonIgnore]
    public virtual ICollection<Choice> Choices {get; set;}

}