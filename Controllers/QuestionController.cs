using Microsoft.AspNetCore.Mvc;
using poll_api.Models;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    protected readonly IQuestionService questionService;

    public QuestionController(IQuestionService service)
    {
        questionService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(questionService.Get());
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(Guid id)
    {
        Question question = questionService.GetQuestionById(id);
        if(question is null)
            return NotFound();
        return Ok(question);
    }

    [HttpPost]
    public IActionResult AddQuestion([FromBody] Question question)
    {
        questionService.Add(question);
        // Metodo correcto a usar faltan pruebas
        return Created("Se creo el recurso", question);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Put(Guid id, [FromBody] Question question)
    {
        questionService.Update(id, question);
        // Se deben actualizar las respuestas de los servicios para adecuarse a los estandares
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Detelte(Guid id)
    {
        questionService.DeleteById(id);
        return Ok();
    }
}