using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace poll_api.Models;

public class Choice
{
    public Guid Id {get; set;}
    public Guid IdQuestion {get; set;}
    public string ChoiceText {get; set;}
    public bool Correct {get; set;}
    
    // Navigation Properties
    [JsonIgnore]
    public virtual Question? Question {get; set;}
    // La eleccion no puede estar seleccionada ?
    [JsonIgnore]
    [ValidateNever]
    public virtual ICollection<UserChoice> UserChoice {get; set;}
}