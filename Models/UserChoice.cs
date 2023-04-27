namespace poll_api.Models;

public class UserChoice
{
    public Guid IdChoice {get; set;}
    public Guid IdUser {get; set;}

    // Navigation Properties
    public virtual User User {get; set;}
    public virtual Choice Choice {get; set;}
    
    // Esta propieda deberia ir en esta tabla?
    // public DateTime VoteDate {get; set;}
}