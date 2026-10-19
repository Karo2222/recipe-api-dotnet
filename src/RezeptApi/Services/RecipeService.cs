using RezeptApi.Models;

namespace RezeptApi.Services;

// Interface + Implementierung, wie bei einem Spring-@Service.
public interface IRecipeService
{
    IReadOnlyList<Recipe> GetAll();
    Recipe? GetById(int id);
    Recipe Add(Recipe recipe);
    bool Delete(int id);
    bool Update(int id, Recipe recipe);
}

public class RecipeService : IRecipeService
{
    private readonly List<Recipe> _recipes = new();
    private int _nextId = 1;

    public IReadOnlyList<Recipe> GetAll() => _recipes;

    public Recipe? GetById(int id) => _recipes.FirstOrDefault(r => r.Id == id);

    public Recipe Add(Recipe recipe)
    {
        recipe.Id = _nextId++;
        _recipes.Add(recipe);
        return recipe;
    }

    public bool Delete(int id)
    {
        var recipe = GetById(id);
        return recipe is not null && _recipes.Remove(recipe);
    }

    public bool Update(int id, Recipe recipe) 
    {
        var oldRecipe = GetById(id);
        if (oldRecipe is null) 
        {
            return false;
        }
    
        oldRecipe.Title = recipe.Title;
        oldRecipe.Ingredients = recipe.Ingredients;
        oldRecipe.Instructions = recipe.Instructions;
        return true;
        
    }
}
