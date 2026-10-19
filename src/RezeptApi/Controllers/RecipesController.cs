using Microsoft.AspNetCore.Mvc;
using RezeptApi.Models;
using RezeptApi.Services;

namespace RezeptApi.Controllers;

// [ApiController] + [Route] entsprechen @RestController + @RequestMapping.
[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _service;

    // Dependency Injection per Konstruktor, wie in Spring.
    public RecipesController(IRecipeService service) => _service = service;

    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetAll() => Ok(_service.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<Recipe> GetById(int id)
    {
        var recipe = _service.GetById(id);
        return recipe is null ? NotFound() : Ok(recipe);
    }

    [HttpPost]
    public ActionResult<Recipe> Create(Recipe recipe)
    {
        var created = _service.Add(recipe);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) => _service.Delete(id) ? NoContent() : NotFound();

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Recipe recipe) => _service.Update(id, recipe) ? Ok(_service.GetById(id)) : NotFound();


}
