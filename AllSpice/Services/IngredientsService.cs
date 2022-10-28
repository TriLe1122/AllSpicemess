namespace AllSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _ingredientsRepo;

  public IngredientsService(IngredientsRepository ingredientsRepo)
  {
    _ingredientsRepo = ingredientsRepo;
  }
}