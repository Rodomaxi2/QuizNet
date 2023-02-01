using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace poll_api.Models;

public class User
{
    public Guid Id {get; set;}
    public string UserName {get;set;}

    // Navigation Properties
    [JsonIgnore]
    [ValidateNever]
    public virtual ICollection<UserChoice> UserChoice {get; set;}
}