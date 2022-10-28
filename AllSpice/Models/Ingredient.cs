namespace AllSpice.Models;


public class Ingredient :  IRepoItem<int>
{

  public int Id { get; set; }
  public int RecipeId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string Quantity { get; set; }
}