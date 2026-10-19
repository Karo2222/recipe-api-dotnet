using RezeptApi.Models;
using RezeptApi.Services;

namespace RezeptApi.Tests;

public class RecipeServiceTests
{
    private static Recipe NewRecipe(string title = "Pasta") => new()
    {
        Title = title,
        Ingredients = new List<string> { "Nudeln", "Tomaten" },
        Instructions = "Kochen."
    };

    [Fact]
    public void Add_AssignsIncreasingIds()
    {
        var service = new RecipeService();

        var first = service.Add(NewRecipe("A"));
        var second = service.Add(NewRecipe("B"));

        Assert.Equal(1, first.Id);
        Assert.Equal(2, second.Id);
        Assert.Equal(2, service.GetAll().Count);
    }

    [Fact]
    public void GetById_ReturnsNull_WhenRecipeDoesNotExist()
    {
        var service = new RecipeService();

        Assert.Null(service.GetById(99));
    }

    [Fact]
    public void Update_ChangesFields_AndKeepsId()
    {
        var service = new RecipeService();
        var created = service.Add(NewRecipe());

        var updated = service.Update(created.Id, new Recipe
        {
            Title = "Pasta Pesto",
            Ingredients = new List<string> { "Nudeln", "Pesto" },
            Instructions = "Mischen."
        });

        Assert.True(updated);
        var stored = service.GetById(created.Id)!;
        Assert.Equal(created.Id, stored.Id);
        Assert.Equal("Pasta Pesto", stored.Title);
        Assert.Equal("Mischen.", stored.Instructions);
    }

    [Fact]
    public void Update_ReturnsFalse_WhenRecipeDoesNotExist()
    {
        var service = new RecipeService();

        Assert.False(service.Update(99, NewRecipe()));
    }

    [Fact]
    public void Delete_RemovesRecipe()
    {
        var service = new RecipeService();
        var created = service.Add(NewRecipe());

        Assert.True(service.Delete(created.Id));
        Assert.Null(service.GetById(created.Id));
    }

    [Fact]
    public void Delete_ReturnsFalse_WhenRecipeDoesNotExist()
    {
        var service = new RecipeService();

        Assert.False(service.Delete(99));
    }
}
