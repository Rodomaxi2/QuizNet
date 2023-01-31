namespace poll_api.Models;

public class Choice
{
    public Guid Id {get; set;}
    public Guid IdQuestion {get; set;}
    public string ChoiceText {get; set;}
    public bool Correct {get; set;}
    
    // Navigation Properties
    public virtual Question Question {get; set;}
    public virtual ICollection<UserChoice> UserChoice {get; set;}
}