public class User
{
    public Guid Id {get; set;}
    public string UserName {get;set;}

    // Navigation Properties
    public virtual ICollection<UserChoice> UserChoice {get; set;}
}